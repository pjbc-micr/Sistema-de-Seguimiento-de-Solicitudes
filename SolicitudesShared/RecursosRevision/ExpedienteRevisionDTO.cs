using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesShared.RecursosRevision
{
    public class ExpedienteRevisionDTO
    {
        public DateTime? FechaNotificacionAdmision { get; set; }
        public string? RespuestaSolicitud { get; set; }
        public DateTime? FechaAcuerdo { get; set; }
        public string? ContenidoAcuerdo { get; set; }
        public string? MateriaRecurso { get; set; }
        public string? RazonInterposicion { get; set; }
        public string? SentidoResolucion { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public string? FolioSolicitud { get; set; }
        public DateTime? FechaContestacionRecurso { get; set; }
        public string? ContenidoAcuerdoFinal { get; set; }
    }
}
