using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesShared.RecursosRevision
{
    public class ExpedienteRevisionDTO
    {
        public int IdExpediente { get; set; }

        // ------------------------------
        // CAMPOS NUEVOS (se agregaron del Recurso)
        // ------------------------------
        public string? NumeroRecurso { get; set; }
        public string? Estatus { get; set; }
        public string? ResolucionSentido { get; set; }
        public string? ContenidoSolicitud { get; set; }
        public string? NombreRecurrente { get; set; }
        public string? SentidoContestacion { get; set; }

        // ------------------------------
        // CAMPOS ORIGINALES DEL EXPEDIENTE
        // ------------------------------
        public DateTime? FechaNotificacionAdmision { get; set; }
        public string? RespuestaSolicitud { get; set; }

        public DateTime? FechaAcuerdo { get; set; }
        public string? ContenidoAcuerdo { get; set; }

        // MATERIA EN LISTBOX (DAI / DP)
        public string? MateriaRecurso { get; set; }

        public string? RazonInterposicion { get; set; }

        public DateTime? FechaNotificacion { get; set; }
        public string? FolioSolicitud { get; set; }

        public DateTime? FechaContestacionRecurso { get; set; }

        public DateTime? FechaAcuerdoFinal { get; set; }
        public string? ContenidoAcuerdoFinal { get; set; }

        // ------------------------------
        // AUXILIAR PARA EDICIÓN EN TABLA
        // ------------------------------
        public bool IsEditing { get; set; } = false;
    }


}
