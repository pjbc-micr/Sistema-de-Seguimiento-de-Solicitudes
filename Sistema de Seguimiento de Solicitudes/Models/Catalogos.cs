namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class Catalogos
    {
        //Etapa Inicial  

        public static List<string> Prevencion = new()
        { 
            "SI", "NO" 
        };


        public static readonly List<string> MesesAdmision = new()
                   {
                       "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO",
                       "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"
                   };

        public static readonly List<string> Estatuses = new()
                   {
                       "INICIO",
                       "PROCESO",
                       "EN PREVENCIÓN",
                       "EN AMPLIACIÓN",
                       "TERMINADA",
                       "DESECHADA",
                       "CANCELADA"
                   };

        public static readonly List<string> TiposSolicitud = new()
                   {
                       "DAI", "ARCO"
                   };

        public static readonly List<string> SolicitudARCO = new()
                   {
                       "ACCESO", "RECTIFICACION", "CANCELACION",
                       "OPOSICION"
                   };

        public static readonly List<string> Ampliacion = new()
                   {
                       "SI", "NO"
                   };

        public static readonly List<string> SubsanaPrevencion = new()
                   {
                       "SI", "NO"
                   };

        // modificar el DTO y la base de datos para esta  
        public static readonly List<string> ComoFueRecibida = new()
                   {
                       "PNT", "MANUAL"
                   };

        // modificar el DTO y la base de datos para esta  
        public static readonly List<string> MedioRecepcionSolicitudManual = new()
                   {
                       "CORREO ELECTRÓNICO", "PRESENTACIÓN EN MÓDULO"
                   };

        public static readonly List<string> ComoDeseaRecibirRespuesta = new()
                   {
                       "ELECTRÓNICO A TRAVÉS DE PNT", "CORREO ELECTRÓNICO", "MEDIO ELECTRÓNICO DEL SOLICITANTE",
                       "COPIA SIMPLE", "COPIA CERTIFICADA", "CUALQUIER OTRO MEDIO ELECTRÓNICO"
                   };

        //Etapa de Seguimiento  

        // 🔥 CATÁLOGO COMBINADO Y ORDENADO ALFABÉTICAMENTE 🔥
        private readonly List<string> CatalogoAreas = new List<string>
    {
        "AUTORIDAD GARANTE DEL PODER JUDICIAL",
        "CENTRO DE CONVIVENCIA FAMILIAR SUPERVISADA",
        "CENTRO ESTATAL DE JUSTICIA ALTERNATIVA",
        "COMISIÓN DE CARRERA JUDICIAL",
        "COMISIÓN DE VIGILANCIA Y DISCIPLINA",
        "COMUNICACIÓN SOCIAL Y RELACIONES PÚBLICAS",
        "CONSEJO DE ADMINISTRACIÓN",
        "CONTRALORÍA",
        "COORDINACIÓN DE PERITAJE",
        "COORDINACIÓN DE PERITOS",
        "DELEGACIÓN DE OFICIALÍA MAYOR EN ENSENADA Y SAN QUINTÍN",
        "DELEGACIÓN DE OFICIALÍA MAYOR EN TIJUANA, TECATE Y PLAYAS DE ROSARITO",
        "DEPARTAMENTO DE CONTABILIDAD Y FINANZAS",
        "DEPARTAMENTO DE INFORMÁTICA",
        "DEPARTAMENTO DE PROGRAMACIÓN Y PRESUPUESTOS",
        "DEPARTAMENTO DE RECURSOS HUMANOS",
        "DEPARTAMENTO DE SERVICIOS GENERALES",
        "DEPARTAMENTO DEL FONDO AUXILIAR",
        "DIRECCIÓN DE PLANEACIÓN, INNOVACIÓN Y ESTADÍSTICA",
        "DIRECCIÓN DE TECNOLOGÍAS DE LA INFORMACIÓN",
        "ESCUELA DE FORMACIÓN JUDICIAL",
        "INSTITUTO DE LA JUDICATURA",
        "OFICIALÍA DE PARTES COMÚN",
        "OFICIALÍA MAYOR",
        "ÓRGANO INTERNO DE CONTROL",
        "SECRETARÍA GENERAL DE ACUERDOS DEL TRIBUNAL SUPERIOR DE JUSTICIA",
        "SECRETARÍA GENERAL DEL CONSEJO DE ADMINISTRACIÓN",
        "SECRETARÍA GENERAL DEL CONSEJO DE LA JUDICATURA",
        "SERVICIO MÉDICO FORENSE",
        "SISTEMA DE JUSTICIA PENAL ORAL",
        "TRIBUNAL DE DISCIPLINA JUDICIAL",
        "TRIBUNAL LABORAL",
        "UNIDAD DE PLANEACIÓN Y DESARROLLO",
        "UNIDAD DE TRANSPARENCIA",
        "UNIDAD JURÍDICA Y ASESORÍA INTERNA"
    };

        // Etapa final  

        public static readonly List<string> Ciudades = new()
                   {
                       "TIJUANA", "MEXICALI", "ENSENADA", "ROSARITO", "TECATE"
                   };

        public static readonly List<string> Cobros = new()
                   {
                       "NINGUNO", "SI"
                   };

        public static readonly List<string> SentidoRespuesta = new()
                   {
                       "AFIRMATIVA", "RESERVADA", "CONFIDENCIAL", "TOTAL INCOMPETENCIA",
                       "PARCIAL INCOMPETENCIA", "NOTORIA INCOMPETENCIA", "IMPROCEDENCIA",
                       "INEXISTENCIA", "DESECHADA", "OTRO"
                   };

        public static readonly List<string> Materia = new()
                   {
                       "CIVIL", "FAMILIAR", "MERCANTIL", "LABORAL", "PENAL", "PENAL ORAL", "OTRO"
                   };

        // requiere los verdaderis valores  
        public static readonly List<string> PrecicionSentidoRespuesta = new()
                   {
                       "PARCIAL", "TOTAL"
                   };

        public static readonly List<string> ModalidadEntrega = new()
                   {
                       "DIGITAL", "DIGITAL/CORREO", "COPIA CERTIFICADA", "COPIA SIMPLE"
                   };

        public static readonly List<string> RecursoRevision = new()
                   {
                       "SI", "NO"
                   };

        public static readonly List<string> Tematica = new()
                   {
                       "ACTIVIDADES DEL CJE", "ACTIVIDADES DEL TSJ",
                       "ACTIVIDADES DE LOS ÓRGANOS JURISDICCIONALES DE PRIMERA INSTANCIA",
                       "ADMINISTRACIÓN JUDICIAL", "DATOS PERSONALES", "DESECHADA",
                       "IMPROCEDENCIA", "INCOMPETENCIA", "INFORMACIÓN ESTADÍSTICA",
                       "MANEJO PRESUPUESTAL", "NOTORIA INCOMPETENCIA", "ORIENTACIÓN",
                       "PRESTACIONES LABORALES", "USO DE RECURSOS PÚBLICOS"
                   };

        // Tematicas Especificas  

        public static readonly List<string> ActividadesCJE = new()
                   {
                       "CARRERA JUDICIAL/PROCEDIMIENTOS DE RATIFICACIÓN",
                       "ACTAS O ACUERDOS DEL PLENO DEL CJE",
                       "CARRERA JUDICIAL/QUEJAS Y PROCEDIMIENTOS DE RESPONSABILIDAD",
                       "CÓDIGO DE ÉTICA",
                       "CONVOCATORIAS Y CONCURSOS DE OPOSICIÓN",
                       "JUSTICIA RESTAURATIVA/ALTERNATIVA",
                       "JUSTICIA TERAPÉUTICA",
                       "ORGANIZACIÓN JURISDICCIONAL",
                       "QUEJAS Y PROCEDIMIENTOS DE RESPONSABILIDAD",
                       "VIGILANCIA Y DISCIPLINA/QUEJAS Y PROCEDIMIENTOS DE RESPONSABILIDAD"
                   };

        public static readonly List<string> ActividadesTSJ = new()
           {
               "ESTADO PROCESAL DE TOCAS",
               "TOTAL DE ASUNTOS RADICADOS",
               "TOTAL DE ASUNTOS RADICADOS/PENAL",
               "VERSIONES PÚBLICAS DE TOCAS"
           };

        public static readonly List<string> ActividadesOrganosJurisdiccionales = new()
           {
               "ACCESO A EXPEDIENTES JUDICIALES",
               "INFORMACIÓN ESTADÍSTICA",
               "TOTAL DE ASUNTO EN TRÁMITE/FAMILIAR",
               "TOTAL DE ASUNTOS EN TRÁMITE/PENAL",
               "TOTAL DE ASUNTOS RADICADOS",
               "TOTAL DE ASUNTOS RADICADOS/CIVIL",
               "TOTAL DE ASUNTOS RADICADOS/FAMILIAR",
               "TOTAL DE ASUNTOS RADICADOS/LABORAL",
               "TOTAL DE ASUNTOS RADICADOS/PENAL",
               "TOTAL DE SENTENCIAS",
               "TOTAL DE SENTENCIAS/PENAL",
               "TOTAL DE SOLICITUDES DE VINCULACIÓN A PROCESO",
               "VERSIONES PÚBLICAS DE EXPEDIENTES",
               "VERSIONES PÚBLICAS DE SENTENCIAS"

           };

        public static readonly List<string> AdministracionJudicial = new()
           {
               "ACCESO A DOCUMENTOS ADMINISTRATIVOS",
               "ADMINISTRACIÓN DE BASES SINDICALES",
               "ATRIBUCIONES DE LAS ÁREAS",
               "DESEMPEÑO LABORAL",
               "INDICADORES DE RESULTADOS",
               "ORGANIGRAMAS",
               "PLANTILLA DE PERSONAL",
               "PRESTACIONES DE SEGURIDAD SOCIAL",
               "QUEJAS ADMINISTRATIVAS"
           };

        public static readonly List<string> InformacionEstadistica = new()
           {
               "CIVIL",
               "FAMILIAR",
               "FAMILIAR/PENSIÓN ALIMENTICIA",
               "INFORMACIÓN ESTADÍSTICA",
               "LABORAL",
               "MEDIDAS CAUTELARES",
               "MERCANTIL",
               "ÓRDENES DE PROTECCIÓN",
               "PENAL",
               "PENAL/CORRUPCIÓN",
               "PENAL/DESAPARICIÓN FORZADA",
               "PENAL/TORTURA",
               "PENAL/TRATA DE PERSONAS",
               "SEMEFO",
               "SEMEFO/CAUSAS DE DEFUNCIÓN"
           };

        public static readonly List<string> ManejoPresupuestal = new()
           {
               "PRESUPUESTO ASIGNADO", "PRESUPUESTO EJERCIDO"
           };

        public static readonly List<string> Orientacion = new()
           {
               "CAPACITACIÓN",
               "COORDINACIÓN DE PERITOS",
               "DIRECTORIO",
               "PROTECCIÓN DE DATOS PERSONALES",
               "RESULTADO DE ACTIVIDADES ADMINISTRATIVAS",
               "SE CANALIZA A POT/PNT",
               "TRÁMITES ADMINISTRATIVOS"
           };

        public static readonly List<string> PrestacionesLaborales = new()
           {
               "PERMISOS CON O SIN GOCE DE SUELDOS", "INCAPACIDADES",
               "SUELDOS",
               "TELÉFONO/VEHÍCULO OFICIAL"
           };

        public static readonly List<string> UsoRecursosPublicos = new()
           {
               "ADQUISICIONES/COMPRAS DE EQUIPO Y MOBILIARIO",
               "CONTRATOS CELEBRADOS",
               "PADRÓN DE PROVEEDORES",
               "VIÁTICOS Y GASTOS DE REPRESENTACIÓN"
           };
    }
}
