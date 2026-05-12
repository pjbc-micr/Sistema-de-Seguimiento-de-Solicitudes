using System;
using System.Collections.Generic;

namespace SolicitudesAPI.Models;

public partial class Expediente
{
    public int Id { get; set; }

    public string? Folio { get; set; }
    public int AnoAdmision { get; set; }
    public string? MesAdmision { get; set; }

    public string? TipoSolicitud { get; set; }

    public string? TipoDerecho { get; set; }

    public string? NombreSolicitante { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaLimiteRespuesta10dias { get; set; }

    public string? Ampliacion { get; set; }

    public int NumeroSesionComiteAmpliacion { get; set; }

    public DateTime? FechaSesionComiteAmpliacion { get; set; }

    public DateTime? FechaLimiteRespuesta20dias { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaRespuesta { get; set; }

    public int PromedioDiasRespuesta { get; set; }

    public bool Prevencion { get; set; }

    public string? SubsanaPrevencionReinicoTramite { get; set; }

    public DateTime? FechaLimitePrevencion10dias { get; set; }

    public string? RecibidaRegistrada { get; set; }

    public string? MedioRecepcionSolicitudManual { get; set; }

    public string? ComoDeseaRecibirRespuestaPersonaSolicitante { get; set; }

    public string? CorreoElectronicoSolicitante { get; set; }

    public string? ContenidoSolicitud { get; set; }

    public string? AreaPoseedoraInformacion { get; set; }

    public string? Materia { get; set; }

    public string? CiudadSolicitante { get; set; }

    public string? Tematica { get; set; }

    public string? TematicaEspecifica { get; set; }

    public string? SentidoRespuesta { get; set; }

    public string? PrecisionSentidoRespuesta { get; set; }

    public string? ModalidadEntrega { get; set; }

    public string? Cobro { get; set; }

    public string? RecursoRevision { get; set; }

    public int NumeroRecursoRevision { get; set; }

    public string? DatosRecursoRevision { get; set; }

    public string? Nota { get; set; }
}
