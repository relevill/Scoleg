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
        #region CP01_Listar Usuario
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
        #endregion
        #region CP02_Ingresar Usuario
        [Given(@"El usuario ingresa a la opción de menú Ingresar Usuarios")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuIngresarUsuarios()
        {
            ingresarUsuarioPage.IngresarMenuIngresarUsuarios();
        }

        [Given(@"El sistema despliega el formulario para ingresar rut de usuario (.*)")]
        public void DadoElSistemaDespliegaElFormularioParaIngresarRutDeUsuario(string RutUsuario)
        {
            ingresarUsuarioPage.IngresarRut(RutUsuario);
        }

        [When(@"El usuario ingresa los datos necesarios para ingresar un nuevo usuario: Nombre (.*), Apellido Paterno (.*), Apellido Materno (.*), Username (.*), Password (.*), Confirmar Password (.*), Telefono (.*), Email (.*),selecciona Sucursal (.*) y selecciona Perfil (.*)")]
        public void CuandoElUsuarioIngresaLosDatosNecesariosParaIngresarUnNuevoUsuarioNombreApellidoPaternoApellidoMaternoUsernamePasswordConfirmarPasswordTelefonoEmailSeleccionaSucursalYSeleccionaPerfil(string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Username, string Password, string ConfirmPassword, string Telefono, string Email, string Sucursal, string Perfil)
        {
            ingresarUsuarioPage.CompletarIngresoUsuario(Nombre, ApellidoPaterno, ApellidoMaterno, Username, Password, ConfirmPassword, Telefono, Email, Sucursal, Perfil);
        }

        [When(@"El usuario pulsa el botón Registrar")]
        public void CuandoElUsuarioPulsaElBotonRegistrar()
        {
            ingresarUsuarioPage.PulsarBotonRegistrar();
        }

        [When(@"El usuario confirma el ingreso del registro")]
        public void CuandoElUsuarioConfirmaElIngresoDelRegistro()
        {
            ingresarUsuarioPage.PulsarConfirmarCreacion();
            ingresarUsuarioPage.PulsarCerrarConfimacion();
        }

        [Then(@"El sistema despliega en la grilla el registro ingresado con el rut (.*)")]
        public void EntoncesElSistemaDespliegaEnLaGrillaElRegistroIngresadoConElRut(string RutUsuario)
        {
            ingresarUsuarioPage.ValidarCreacionRegistroGrupoUsuarios(RutUsuario);
        }

        #endregion
        #region CP03_Editar Usuario
        [Given(@"El usuario pulsa el botón Detalle para el registro el rut (.*)")]
        public void DadoElUsuarioPulsaElBotonDetalleParaElRegistroElRut(string RutUsuario)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"El usuario reemplaza los datos del usuario con la siguiente información: Nombre (.*), Apellido Paterno (.*), Apellido Materno (.*), Username (.*), Password (.*), Confirmar Password (.*), Telefono (.*), Email (.*),selecciona Sucursal (.*) y selecciona Perfil (.*)")]
        public void CuandoElUsuarioReemplazaLosDatosDelUsuarioConLaSiguienteInformacionNombreApellidoPaternoApellidoMaternoUsernamePasswordConfirmarPasswordTelefonoEmailSeleccionaSucursalYSeleccionaPerfil(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"El usuario pulsa el botón Editar")]
        public void CuandoElUsuarioPulsaElBotonEditar()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"El usuario confirma a edición del registro")]
        public void CuandoElUsuarioConfirmaAEdicionDelRegistro()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"El sistema despliega en la grilla el registro modificado con el rut (.*)")]
        public void EntoncesElSistemaDespliegaEnLaGrillaElRegistroModificadoConElRut(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
    }
}
