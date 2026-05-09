using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolicitudesAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModuloComiteTransparencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.CreateTable(
            //    name: "Calendario",
              //  columns: table => new
                //{
                  //  ID = table.Column<int>(type: "int", nullable: false),
                    //Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                   // Activo = table.Column<bool>(type: "bit", nullable: false)
                //},
                //constraints: table =>
                //{
                 //   table.PrimaryKey("PK_Calendario", x => x.ID);
               // });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RazonInterposicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FraccionArticulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstatusActual = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaAdmision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInformeJustificado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentidoInforme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCierreInstruccion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaResolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentidoResolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaEstado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "DiaInhabilManual",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DiaInhabilManual", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Expedientes",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Folio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        MesAdmision = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TipoSolicitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TipoDerecho = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NombreSolicitante = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
            //        FechaLimiteRespuesta10dias = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Ampliacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NumeroSesionComiteAmpliacion = table.Column<int>(type: "int", nullable: false),
            //        FechaSesionComiteAmpliacion = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        FechaLimiteRespuesta20dias = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        PromedioDiasRespuesta = table.Column<int>(type: "int", nullable: false),
            //        Prevencion = table.Column<bool>(type: "bit", nullable: false),
            //        SubsanaPrevencion_ReinicoTramite = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        FechaLimitePrevencion10dias = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        RecibidaRegistrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        MedioRecepcionSolicitudManual = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ComoDeseaRecibirRespuestaPersonaSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CorreoElectronicoSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ContenidoSolicitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        AreaPoseedoraInformacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Materia = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CiudadSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Tematica = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TematicaEspecifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SentidoRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PrecisionSentidoRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ModalidadEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Cobro = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RecursoRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NumeroRecursoRevision = table.Column<int>(type: "int", nullable: false),
            //        DatosRecursoRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Nota = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Solicitu__3214EC27AA69A3A2", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Usuarios",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NombreUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        password = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: false),
            //        Rol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Usuarios__3214EC27AA69A3A2", x => x.ID);
            //    });

            migrationBuilder.CreateTable(
                name: "AcuerdosSeguimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenunciaId = table.Column<int>(type: "int", nullable: false),
                    FechaAcuerdo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContenidoAcuerdo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcuerdosSeguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcuerdosSeguimiento_Denuncias_DenunciaId",
                        column: x => x.DenunciaId,
                        principalTable: "Denuncias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpedientesDigitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenunciaId = table.Column<int>(type: "int", nullable: false),
                    NombreDocumento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedientesDigitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpedientesDigitales_Denuncias_DenunciaId",
                        column: x => x.DenunciaId,
                        principalTable: "Denuncias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcuerdosSeguimiento_DenunciaId",
                table: "AcuerdosSeguimiento",
                column: "DenunciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedientesDigitales_DenunciaId",
                table: "ExpedientesDigitales",
                column: "DenunciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcuerdosSeguimiento");

            //migrationBuilder.DropTable(
            //    name: "Calendario");

            //migrationBuilder.DropTable(
            //    name: "DiaInhabilManual");

            //migrationBuilder.DropTable(
            //    name: "Expedientes");

            migrationBuilder.DropTable(
                name: "ExpedientesDigitales");

            //migrationBuilder.DropTable(
            //    name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Denuncias");
        }
    }
}
