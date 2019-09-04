using AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S03_Usuario;
using AutomatizacionScoleg.Utilidades.Pages;
using System;
using TechTalk.SpecFlow;

namespace AutomatizacionScoleg.Steps.M02_Adm._Usuarios
{
    [Scope(Feature = "M02 Adm. Usuarios_S03 Usuario")]
    [Binding]
    public class M02Adm_Usuarios_S03UsuarioSteps : BasePage
    {
        //Establecer objeto clase S1_SesionSteps
        private static ListarUsuarioPage listarUsuarioPage;
        private static IngresarUsuarioPage ingresarUsuarioPage;
        private static EditarUsuarioPage editarUsuarioPage;
        private static EliminarUsuarioPage eliminarUsuarioPage;
        private static VerDetalleUsuarioPage verDetalleUsuarioPage;

        //Constructor de la clase
        public M02Adm_Usuarios_S03UsuarioSteps()
        {
            listarUsuarioPage = new ListarUsuarioPage();
            ingresarUsuarioPage = new IngresarUsuarioPage();
            editarUsuarioPage = new EditarUsuarioPage();
            eliminarUsuarioPage = new EliminarUsuarioPage();
            verDetalleUsuarioPage = new VerDetalleUsuarioPage();
        }
        [Given(@"El usuario ingresa a la opcion de menú Listar Usuarios")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuListarUsuarios()
        {
            listarUsuarioPage.IngresarMenuListarUsuarios();
        }
        
        [Then(@"El sistema despliega una grilla con los registros de usuarios existentes en el sistema")]
        public void EntoncesElSistemaDespliegaUnaGrillaConLosRegistrosDeUsuariosExistentesEnElSistema()
        {
            listarUsuarioPage.ValidarCantidadRegistrosGrilla();
        }
    }
}
