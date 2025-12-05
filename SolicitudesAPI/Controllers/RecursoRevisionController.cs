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

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar(RecursoRevisionDTO modelo)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string query = @"
                INSERT INTO MT_RECURSO_REVISION
                (NUMERO_RECURSO, ESTATUS, CONTENIDO_SOLICITUD, NOMBRE_RECURRENTE, SENTIDO_CONTESTACION, FECHA_ACUERDO)
                VALUES (@NUMERO, @ESTATUS, @CONTENIDO, @RECURRENTE, @SENTIDO, @FECHA)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NUMERO", modelo.NumeroRecurso ?? "");
                    cmd.Parameters.AddWithValue("@ESTATUS", modelo.Estatus ?? "");
                    cmd.Parameters.AddWithValue("@CONTENIDO", modelo.ContenidoSolicitud ?? "");
                    cmd.Parameters.AddWithValue("@RECURRENTE", modelo.NombreRecurrente ?? "");
                    cmd.Parameters.AddWithValue("@SENTIDO", modelo.SentidoContestacion ?? "");
                    cmd.Parameters.AddWithValue("@FECHA", modelo.FechaAcuerdo);

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                }
            }

            return Ok(new { mensaje = "Guardado correctamente" });
        }
        [HttpPost("Expediente")]
        public async Task<IActionResult> GuardarExpediente(ExpedienteRevisionDTO modelo)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string query = @"
        INSERT INTO MT_EXPEDIENTE_RECURSO
        (FECHA_NOTIFICACION_ADMISION, RESPUESTA_SOLICITUD, FECHA_ACUERDO, CONTENIDO_ACUERDO,
         MATERIA_RECURSO, RAZON_INTERPOSICION, SENTIDO_RESOLUCION, FECHA_NOTIFICACION,
         FOLIO_SOLICITUD, FECHA_CONTESTACION_RECURSO, CONTENIDO_ACUERDO_FINAL)
        VALUES
        (@F1, @F2, @F3, @F4, @F5, @F6, @F7, @F8, @F9, @F10, @F11)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@F1", modelo.FechaNotificacionAdmision ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F2", modelo.RespuestaSolicitud ?? "");
                    cmd.Parameters.AddWithValue("@F3", modelo.FechaAcuerdo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F4", modelo.ContenidoAcuerdo ?? "");
                    cmd.Parameters.AddWithValue("@F5", modelo.MateriaRecurso ?? "");
                    cmd.Parameters.AddWithValue("@F6", modelo.RazonInterposicion ?? "");
                    cmd.Parameters.AddWithValue("@F7", modelo.SentidoResolucion ?? "");
                    cmd.Parameters.AddWithValue("@F8", modelo.FechaNotificacion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F9", modelo.FolioSolicitud ?? "");
                    cmd.Parameters.AddWithValue("@F10", modelo.FechaContestacionRecurso ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F11", modelo.ContenidoAcuerdoFinal ?? "");

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return Ok(new { mensaje = "Expediente guardado correctamente" });
        }

        [HttpPost("Expediente/PDF")]
        public IActionResult GenerarPDF([FromBody] ExpedienteRevisionDTO modelo)
        {
            try
            {
                // Crea el documento (tu clase debe implementar IDocument)
                var documento = new ExpedienteRevisionPDF(modelo);

                // Genera el PDF en memoria (compatible con distintas versiones de QuestPDF)
                using var ms = new System.IO.MemoryStream();

                // Si tu versión soporta GeneratePdf(Stream)
                // esto es lo más compatible y seguro:
                documento.GeneratePdf(ms);

                // Asegurarse de posicionar al inicio
                ms.Position = 0;
                var pdfBytes = ms.ToArray();

                // Devuelve el PDF al cliente
                return File(pdfBytes, "application/pdf", "ExpedienteRevision.pdf");
            }
            catch (Exception ex)
            {
                // Devuelve detalle mínimo para debug (puedes quitar el mensaje en producción)
                return StatusCode(500, new { error = "Error generando PDF", detail = ex.Message });
            }
        }

        [HttpGet("Expediente/Buscar")]
        public async Task<IActionResult> BuscarExpediente([FromQuery] string folio)
        {
            if (string.IsNullOrWhiteSpace(folio))
                return Ok(new List<ExpedienteRevisionDTO>());

            var lista = new List<ExpedienteRevisionDTO>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string query = @"
            SELECT TOP 20 *
            FROM MT_EXPEDIENTE_RECURSO
            WHERE FOLIO_SOLICITUD LIKE @FOLIO + '%'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FOLIO", folio);

                    con.Open();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
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
                                SentidoResolucion = dr["SENTIDO_RESOLUCION"]?.ToString(),
                                FechaNotificacion = dr["FECHA_NOTIFICACION"] as DateTime?,
                                FolioSolicitud = dr["FOLIO_SOLICITUD"]?.ToString(),
                                FechaContestacionRecurso = dr["FECHA_CONTESTACION_RECURSO"] as DateTime?,
                                ContenidoAcuerdoFinal = dr["CONTENIDO_ACUERDO_FINAL"]?.ToString()
                            });
                        }
                    }
                }
            }

            return Ok(lista);
        }
        // ============================================================
        //   ACTUALIZAR EXPEDIENTE (PUT)
        // ============================================================
        [HttpPut("Expediente/Actualizar")]
        public async Task<IActionResult> ActualizarExpediente([FromBody] ExpedienteRevisionDTO modelo)
        {
            if (modelo.IdExpediente <= 0)
                return BadRequest("IdExpediente inválido");

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string query = @"
            UPDATE MT_EXPEDIENTE_RECURSO SET
                FECHA_NOTIFICACION_ADMISION = @F1,
                RESPUESTA_SOLICITUD = @F2,
                FECHA_ACUERDO = @F3,
                CONTENIDO_ACUERDO = @F4,
                MATERIA_RECURSO = @F5,
                RAZON_INTERPOSICION = @F6,
                SENTIDO_RESOLUCION = @F7,
                FECHA_NOTIFICACION = @F8,
                FOLIO_SOLICITUD = @F9,
                FECHA_CONTESTACION_RECURSO = @F10,
                CONTENIDO_ACUERDO_FINAL = @F11
            WHERE ID_EXPEDIENTE = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", modelo.IdExpediente);

                    cmd.Parameters.AddWithValue("@F1", modelo.FechaNotificacionAdmision ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F2", modelo.RespuestaSolicitud ?? "");
                    cmd.Parameters.AddWithValue("@F3", modelo.FechaAcuerdo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F4", modelo.ContenidoAcuerdo ?? "");
                    cmd.Parameters.AddWithValue("@F5", modelo.MateriaRecurso ?? "");
                    cmd.Parameters.AddWithValue("@F6", modelo.RazonInterposicion ?? "");
                    cmd.Parameters.AddWithValue("@F7", modelo.SentidoResolucion ?? "");
                    cmd.Parameters.AddWithValue("@F8", modelo.FechaNotificacion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F9", modelo.FolioSolicitud ?? "");
                    cmd.Parameters.AddWithValue("@F10", modelo.FechaContestacionRecurso ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@F11", modelo.ContenidoAcuerdoFinal ?? "");

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return Ok(new { mensaje = "Expediente actualizado correctamente" });
        }




    }
}
