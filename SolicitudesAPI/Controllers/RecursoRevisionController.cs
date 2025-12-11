using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QuestPDF.Fluent;
using SolicitudesAPI.PDF;
using SolicitudesShared.RecursosRevision;
using System.Data;

namespace SolicitudesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursoRevisionController : ControllerBase
    {
        private readonly IConfiguration _config;

        public RecursoRevisionController(IConfiguration config)
        {
            _config = config;
        }

        //--------------------------------------------------------------------
        //   AGREGAR RECURSO DE REVISIÓN (Pantalla Agregar Recurso)
        //--------------------------------------------------------------------
        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar(RecursoRevisionDTO modelo)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            string query = @"
            INSERT INTO MT_RECURSO_REVISION
            (NUMERO_RECURSO, ESTATUS, RESOLUCION_SENTIDO,
             CONTENIDO_SOLICITUD, NOMBRE_RECURRENTE, SENTIDO_CONTESTACION,
             FECHA_ACUERDO, CONTENIDO_ACUERDO, FECHA_REGISTRO)
            VALUES
            (@NumeroRecurso, @Estatus, @ResolucionSentido,
             @ContenidoSolicitud, @NombreRecurrente, @SentidoContestacion,
             @FechaAcuerdo, @ContenidoAcuerdo, GETDATE());
            ";

            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@NumeroRecurso", modelo.NumeroRecurso ?? "");
            cmd.Parameters.AddWithValue("@Estatus", modelo.Estatus ?? "");
            cmd.Parameters.AddWithValue("@ResolucionSentido", modelo.ResolucionSentido ?? "");
            cmd.Parameters.AddWithValue("@ContenidoSolicitud", modelo.ContenidoSolicitud ?? "");
            cmd.Parameters.AddWithValue("@NombreRecurrente", modelo.NombreRecurrente ?? "");
            cmd.Parameters.AddWithValue("@SentidoContestacion", modelo.SentidoContestacion ?? "");
            cmd.Parameters.AddWithValue("@FechaAcuerdo", modelo.FechaAcuerdo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ContenidoAcuerdo", modelo.ContenidoAcuerdo ?? "");

            con.Open();
            await cmd.ExecuteNonQueryAsync();

            return Ok(new { mensaje = "Guardado correctamente" });
        }

        //--------------------------------------------------------------------
        //   GUARDAR EXPEDIENTE
        //--------------------------------------------------------------------
        [HttpPost("Expediente")]
        public async Task<IActionResult> GuardarExpediente(ExpedienteRevisionDTO modelo)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            string query = @"
            INSERT INTO MT_EXPEDIENTE_RECURSO
            (FECHA_NOTIFICACION_ADMISION, RESPUESTA_SOLICITUD, FECHA_ACUERDO, CONTENIDO_ACUERDO,
             MATERIA_RECURSO, RAZON_INTERPOSICION, FECHA_NOTIFICACION,
             FOLIO_SOLICITUD, FECHA_CONTESTACION_RECURSO,
             FECHA_ACUERDO_FINAL, CONTENIDO_ACUERDO_FINAL,
             NUMERO_RECURSO, ESTATUS, RESOLUCION_SENTIDO,
             CONTENIDO_SOLICITUD, NOMBRE_RECURRENTE, SENTIDO_CONTESTACION)
            VALUES
            (@F1, @F2, @F3, @F4, @F5, @F6, @F7, @F8, @F9, @F10, @F11,
             @F12, @F13, @F14, @F15, @F16, @F17);
            ";

            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@F1", modelo.FechaNotificacionAdmision ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F2", modelo.RespuestaSolicitud ?? "");
            cmd.Parameters.AddWithValue("@F3", modelo.FechaAcuerdo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F4", modelo.ContenidoAcuerdo ?? "");
            cmd.Parameters.AddWithValue("@F5", modelo.MateriaRecurso ?? "");
            cmd.Parameters.AddWithValue("@F6", modelo.RazonInterposicion ?? "");
            cmd.Parameters.AddWithValue("@F7", modelo.FechaNotificacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F8", modelo.FolioSolicitud ?? "");
            cmd.Parameters.AddWithValue("@F9", modelo.FechaContestacionRecurso ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F10", modelo.FechaAcuerdoFinal ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F11", modelo.ContenidoAcuerdoFinal ?? "");

            // Nuevos campos del recurso
            cmd.Parameters.AddWithValue("@F12", modelo.NumeroRecurso ?? "");
            cmd.Parameters.AddWithValue("@F13", modelo.Estatus ?? "");
            cmd.Parameters.AddWithValue("@F14", modelo.ResolucionSentido ?? "");
            cmd.Parameters.AddWithValue("@F15", modelo.ContenidoSolicitud ?? "");
            cmd.Parameters.AddWithValue("@F16", modelo.NombreRecurrente ?? "");
            cmd.Parameters.AddWithValue("@F17", modelo.SentidoContestacion ?? "");

            con.Open();
            await cmd.ExecuteNonQueryAsync();

            return Ok(new { mensaje = "Expediente guardado correctamente" });
        }

        //--------------------------------------------------------------------
        //   GENERAR PDF
        //--------------------------------------------------------------------
        [HttpPost("Expediente/PDF")]
        public IActionResult GenerarPDF([FromBody] ExpedienteRevisionDTO modelo)
        {
            try
            {
                var documento = new ExpedienteRevisionPDF(modelo);
                using var ms = new MemoryStream();
                documento.GeneratePdf(ms);
                ms.Position = 0;

                return File(ms.ToArray(), "application/pdf", "ExpedienteRevision.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error generando PDF", detail = ex.Message });
            }
        }

        //--------------------------------------------------------------------
        //   BUSCAR EXPEDIENTES POR FOLIO O NÚMERO DE RECURSO (MODIFICADO)
        //--------------------------------------------------------------------
        [HttpGet("Expediente/Buscar")]
        public async Task<IActionResult> BuscarExpediente([FromQuery] string folio)
        {
            if (string.IsNullOrWhiteSpace(folio))
                return Ok(new List<ExpedienteRevisionDTO>());

            var lista = new List<ExpedienteRevisionDTO>();

            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            string query = @"
            SELECT TOP 20 *
            FROM MT_EXPEDIENTE_RECURSO
            WHERE FOLIO_SOLICITUD LIKE @BUSQUEDA + '%'
            OR NUMERO_RECURSO LIKE @BUSQUEDA + '%' -- <-- Nueva condición de búsqueda
            ";

            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BUSQUEDA", folio); // Usamos el parámetro 'folio' como término de búsqueda genérico

            con.Open();
            using var dr = await cmd.ExecuteReaderAsync();

            while (await dr.ReadAsync())
            {
                lista.Add(new ExpedienteRevisionDTO
                {
                    IdExpediente = dr.GetInt32(dr.GetOrdinal("ID_EXPEDIENTE")),
                    FechaNotificacionAdmision = dr["FECHA_NOTIFICACION_ADMISION"] as DateTime?,
                    RespuestaSolicitud = dr["RESPUESTA_SOLICITUD"]?.ToString(),
                    FechaAcuerdo = dr["FECHA_ACUERDO"] as DateTime?,
                    ContenidoAcuerdo = dr["CONTENIDO_ACUERDO"]?.ToString(),
                    MateriaRecurso = dr["MATERIA_RECURSO"]?.ToString(),
                    RazonInterposicion = dr["RAZON_INTERPOSICION"]?.ToString(),
                    FechaNotificacion = dr["FECHA_NOTIFICACION"] as DateTime?,
                    FolioSolicitud = dr["FOLIO_SOLICITUD"]?.ToString(),
                    FechaContestacionRecurso = dr["FECHA_CONTESTACION_RECURSO"] as DateTime?,
                    FechaAcuerdoFinal = dr["FECHA_ACUERDO_FINAL"] as DateTime?,
                    ContenidoAcuerdoFinal = dr["CONTENIDO_ACUERDO_FINAL"]?.ToString(),

                    NumeroRecurso = dr["NUMERO_RECURSO"]?.ToString(),
                    Estatus = dr["ESTATUS"]?.ToString(),
                    ResolucionSentido = dr["RESOLUCION_SENTIDO"]?.ToString(),
                    ContenidoSolicitud = dr["CONTENIDO_SOLICITUD"]?.ToString(),
                    NombreRecurrente = dr["NOMBRE_RECURRENTE"]?.ToString(),
                    SentidoContestacion = dr["SENTIDO_CONTESTACION"]?.ToString()
                });
            }

            return Ok(lista);
        }

        //--------------------------------------------------------------------
        //   ACTUALIZAR EXPEDIENTE
        //--------------------------------------------------------------------
        [HttpPut("Expediente/Actualizar")]
        public async Task<IActionResult> ActualizarExpediente([FromBody] ExpedienteRevisionDTO modelo)
        {
            if (modelo.IdExpediente <= 0)
                return BadRequest("IdExpediente inválido");

            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            string query = @"
            UPDATE MT_EXPEDIENTE_RECURSO SET
                FECHA_NOTIFICACION_ADMISION = @F1,
                RESPUESTA_SOLICITUD = @F2,
                FECHA_ACUERDO = @F3,
                CONTENIDO_ACUERDO = @F4,
                MATERIA_RECURSO = @F5,
                RAZON_INTERPOSICION = @F6,
                FECHA_NOTIFICACION = @F7,
                FOLIO_SOLICITUD = @F8,
                FECHA_CONTESTACION_RECURSO = @F9,
                FECHA_ACUERDO_FINAL = @F10,
                CONTENIDO_ACUERDO_FINAL = @F11,
                NUMERO_RECURSO = @F12,
                ESTATUS = @F13,
                RESOLUCION_SENTIDO = @F14,
                CONTENIDO_SOLICITUD = @F15,
                NOMBRE_RECURRENTE = @F16,
                SENTIDO_CONTESTACION = @F17
            WHERE ID_EXPEDIENTE = @ID
            ";

            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", modelo.IdExpediente);

            cmd.Parameters.AddWithValue("@F1", modelo.FechaNotificacionAdmision ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F2", modelo.RespuestaSolicitud ?? "");
            cmd.Parameters.AddWithValue("@F3", modelo.FechaAcuerdo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F4", modelo.ContenidoAcuerdo ?? "");
            cmd.Parameters.AddWithValue("@F5", modelo.MateriaRecurso ?? "");
            cmd.Parameters.AddWithValue("@F6", modelo.RazonInterposicion ?? "");
            cmd.Parameters.AddWithValue("@F7", modelo.FechaNotificacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F8", modelo.FolioSolicitud ?? "");
            cmd.Parameters.AddWithValue("@F9", modelo.FechaContestacionRecurso ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F10", modelo.FechaAcuerdoFinal ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@F11", modelo.ContenidoAcuerdoFinal ?? "");
            cmd.Parameters.AddWithValue("@F12", modelo.NumeroRecurso ?? "");
            cmd.Parameters.AddWithValue("@F13", modelo.Estatus ?? "");
            cmd.Parameters.AddWithValue("@F14", modelo.ResolucionSentido ?? "");
            cmd.Parameters.AddWithValue("@F15", modelo.ContenidoSolicitud ?? "");
            cmd.Parameters.AddWithValue("@F16", modelo.NombreRecurrente ?? "");
            cmd.Parameters.AddWithValue("@F17", modelo.SentidoContestacion ?? "");

            con.Open();
            await cmd.ExecuteNonQueryAsync();

            return Ok(new { mensaje = "Expediente actualizado correctamente" });
        }
    }
}