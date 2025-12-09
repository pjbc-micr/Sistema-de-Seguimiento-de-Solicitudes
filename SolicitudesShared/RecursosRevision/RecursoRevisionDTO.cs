using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesShared.RecursosRevision
{
    public class RecursoRevisionDTO
    {
        // Datos base del recurso
        public int Id { get; set; }
        public string? NumeroRecurso { get; set; }
        public string? Estatus { get; set; }
        public string? ResolucionSentido { get; set; }
        public string? ContenidoSolicitud { get; set; }
        public string? NombreRecurrente { get; set; }
        public string? SentidoContestacion { get; set; }
        public DateTime? FechaAcuerdo { get; set; }     // ← CORRECTO
        public string? ContenidoAcuerdo { get; set; }


        // ----- Datos usados en el registro simple (RecursoRevisionRegistro.razor) -----
        public int SolicitudId { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
    }
}
