
using System.Configuration;

namespace AutomatizacionScoleg.Utilidades
{
    public static class ParametrosEjecucion
    {
        #region "Variables de la Clase"
        //Establecer url de ambiente desde app.config.
        public static string RutaDelSitio = ConfigurationManager.AppSettings["QA"];

        //Establecer navegador desde app.config.
        public static string Navegador = ConfigurationManager.AppSettings["Navegador"];

        //Establecer valores de inicio de sesión
        public const string Usuario = "19.403.866-6";
        public const string Password = "34567890";
        #endregion
    }
}
