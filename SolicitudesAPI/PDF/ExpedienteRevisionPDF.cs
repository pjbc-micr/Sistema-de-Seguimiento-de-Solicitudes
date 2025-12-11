using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SolicitudesShared.RecursosRevision;
using System.IO;

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

        public DocumentSettings GetSettings() => new DocumentSettings();

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);

                // ======================================================
                // ENCABEZADO CON LOGO + TÍTULO
                // ======================================================
                page.Header().Row(row =>
                {
                    // LOGO
                    row.RelativeItem(1).Column(col =>
                    {
                        try
                        {
                            var logoPath = Path.Combine(
                                "Sistema de Seguimiento de Solicitudes",
                                "wwwroot",
                                "LogoPortal.png"
                            );

                            if (File.Exists(logoPath))
                            {
                                // CORRECCIÓN: Usar la nueva sintaxis de ImageDescriptor
                                col.Item().Image(logoPath).FitWidth();
                            }
                            else
                            {
                                col.Item().Text("LOGO NO ENCONTRADO")
                                    .FontSize(10).Italic();
                            }
                        }
                        catch
                        {
                            col.Item().Text("Error al cargar logo")
                                .FontSize(10);
                        }
                    });

                    // TÍTULO - CORRECCIÓN 1: Aplicar AlignCenter al contenedor (.Item())
                    row.RelativeItem(3).Column(col =>
                    {
                        col.Item().AlignCenter().Text("Expediente Digital del Recurso de Revisión") // CORREGIDO
                            .FontSize(20)
                            .Bold();

                        col.Item().AlignCenter().Text($"Folio: {Datos.FolioSolicitud}") // CORREGIDO
                            .FontSize(12);
                    });
                });

                page.Content().PaddingVertical(15).Column(col =>
                {
                    // ======================================================
                    // SECCIÓN I - DATOS DEL RECURSO
                    // ======================================================
                    col.Item().PaddingBottom(10).Text("I. Datos del Recurso")
                        .FontSize(16)
                        .Bold()
                        .Underline();

                    col.Item().Border(1).BorderColor(Colors.Grey.Medium).Table(t =>
                    {
                        t.ColumnsDefinition(c =>
                        {
                            c.ConstantColumn(250);
                            c.RelativeColumn();
                        });

                        // CORRECCIÓN 2: Usar bloque de código para llamar a t.Cell() por separado
                        void Row(string label, string value)
                        {
                            t.Cell().Padding(5).Text(label).Bold();
                            t.Cell().Padding(5).Text(value);
                        }

                        Row("Número de Recurso", Datos.NumeroRecurso ?? "--");
                        Row("Estatus", Datos.Estatus ?? "--");
                        Row("Resolución en Sentido", Datos.ResolucionSentido ?? "--");
                        Row("Nombre del Solicitante", Datos.NombreRecurrente ?? "--");
                        Row("Contenido de la Solicitud", Datos.ContenidoSolicitud ?? "--");
                        Row("Sentido de Contestación", Datos.SentidoContestacion ?? "--");
                    });

                    col.Item().PaddingTop(20);

                    // ======================================================
                    // SECCIÓN II - DATOS DEL EXPEDIENTE
                    // ======================================================
                    col.Item().PaddingBottom(10).Text("II. Datos del Expediente")
                        .FontSize(16)
                        .Bold()
                        .Underline();

                    col.Item().Border(1).BorderColor(Colors.Grey.Medium).Table(t =>
                    {
                        t.ColumnsDefinition(c =>
                        {
                            c.ConstantColumn(250);
                            c.RelativeColumn();
                        });

                        // CORRECCIÓN 2: Usar bloque de código para llamar a t.Cell() por separado
                        void Row(string label, string? value)
                        {
                            t.Cell().Padding(5).Text(label).Bold();
                            t.Cell().Padding(5).Text(value ?? "--");
                        }

                        Row("Fecha de notificación de la admisión",
                            Datos.FechaNotificacionAdmision?.ToString("dd/MM/yyyy"));

                        Row("Respuesta de la Solicitud", Datos.RespuestaSolicitud);
                        Row("Fecha de acuerdo", Datos.FechaAcuerdo?.ToString("dd/MM/yyyy"));
                        Row("Contenido del acuerdo", Datos.ContenidoAcuerdo);
                        Row("Materia del Recurso", Datos.MateriaRecurso);
                        Row("Razón de la Interposición", Datos.RazonInterposicion);
                        Row("Fecha de Notificación", Datos.FechaNotificacion?.ToString("dd/MM/yyyy"));
                        Row("Fecha Contestación Recurso", Datos.FechaContestacionRecurso?.ToString("dd/MM/yyyy"));
                        Row("Fecha de Acuerdo Final", Datos.FechaAcuerdoFinal?.ToString("dd/MM/yyyy"));
                        Row("Contenido Acuerdo Final", Datos.ContenidoAcuerdoFinal);
                    });

                    col.Item().PaddingTop(20);

                    // ======================================================
                    // SECCIÓN III - IDENTIFICACIÓN
                    // ======================================================
                    col.Item().PaddingBottom(10).Text("III. Identificación del Expediente")
                        .FontSize(16)
                        .Bold()
                        .Underline();

                    col.Item().Border(1).BorderColor(Colors.Grey.Medium)
                        .Padding(10)
                        .Row(row =>
                        {
                            row.RelativeItem().Text("Folio de la Solicitud:").Bold();
                            row.RelativeItem().Text(Datos.FolioSolicitud ?? "--");
                        });
                });

                // ======================================================
                // PIE DE PÁGINA INSTITUCIONAL A LA DERECHA
                // ======================================================
                page.Footer().AlignRight().Column(col =>
                {
                    col.Item().Text("Calle Dr. Humberto Torres #167, esquina con Avenida Pioneros")
                        .FontSize(9);

                    col.Item().Text("Centro Cívico")
                        .FontSize(9);

                    col.Item().Text("Mexicali, Baja California C.P. 21000")
                        .FontSize(9);

                    col.Item().Text("(686) 900-9099 Ext. 1000")
                        .FontSize(9);

                    col.Item().Text("contacto@pjbc.gob.mx")
                        .FontSize(9);

                    col.Item().PaddingTop(5)
                        .Text($"Generado el {DateTime.Now:dd/MM/yyyy}")
                        .FontSize(9)
                        .Italic();
                });
            });
        }
    }
}