using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SolicitudesShared.RecursosRevision;

namespace SolicitudesAPI.PDF
{
    public class ExpedienteRevisionPDF : IDocument
    {
        public ExpedienteRevisionDTO Datos { get; }

        public ExpedienteRevisionPDF(ExpedienteRevisionDTO datos)
        {
            Datos = datos;
        }

        public DocumentMetadata GetMetadata() => new DocumentMetadata();

        // *** ESTA ES LA ÚNICA VERSIÓN COMPATIBLE ***
        public DocumentSettings GetSettings() => new DocumentSettings();

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);

                // ENCABEZADO
                page.Header()
                    .Text("Expediente Digital del Recurso de Revisión")
                    .FontSize(20)
                    .Bold();

                // TABLA
                page.Content().Table(t =>
                {
                    t.ColumnsDefinition(c =>
                    {
                        c.ConstantColumn(260);
                        c.RelativeColumn();
                    });

                    void Row(string etiqueta, string? valor)
                    {
                        t.Cell().Padding(5).BorderBottom(1).Text(etiqueta).Bold();
                        t.Cell().Padding(5).BorderBottom(1).Text(valor ?? "--");
                    }

                    Row("Fecha de notificación de la admisión",
                        Datos.FechaNotificacionAdmision?.ToString("dd/MM/yyyy"));

                    Row("Respuesta de la Solicitud", Datos.RespuestaSolicitud);
                    Row("Fecha de acuerdo", Datos.FechaAcuerdo?.ToString("dd/MM/yyyy"));
                    Row("Contenido del acuerdo", Datos.ContenidoAcuerdo);
                    Row("Materia del recurso", Datos.MateriaRecurso);
                    Row("Razón de la interposición", Datos.RazonInterposicion);
                    Row("Sentido de la resolución", Datos.SentidoResolucion);
                    Row("Fecha de notificación", Datos.FechaNotificacion?.ToString("dd/MM/yyyy"));
                    Row("Folio de la solicitud", Datos.FolioSolicitud);
                    Row("Fecha contestación recurso", Datos.FechaContestacionRecurso?.ToString("dd/MM/yyyy"));
                    Row("Acuerdo final y contenido", Datos.ContenidoAcuerdoFinal);
                });

                // PIE DE PÁGINA
                page.Footer()
                    .AlignRight()
                    .Text($"Generado el {DateTime.Now:dd/MM/yyyy}");
            });
        }
    }
}
