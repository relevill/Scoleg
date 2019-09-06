using AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S02_Perfil;
using AutomatizacionScoleg.Utilidades.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomatizacionScoleg.Steps.M02_Adm._Usuarios
{
    [Scope(Feature = "M02 Adm. Usuarios_S02 Perfil")]
    [Binding]
    public class M02Adm_Usuarios_S02PerfilSteps : BasePage
    {

        //Establecer objeto clase S1_SesionSteps
        private static ListarPerfilPage listarPerfilPage;
        private static IngresarPerfilPage ingresarPerfilPage;
        private static EditarPerfilPage editarPerfilPage;
        private static EliminarPerfilPage eliminarPerfilPage;
        private static VerDetallePerfilPage verDetallePerfilPage;

        //Constructor de la clase
        public M02Adm_Usuarios_S02PerfilSteps()
        {
            listarPerfilPage = new ListarPerfilPage();
            ingresarPerfilPage = new IngresarPerfilPage();
            editarPerfilPage = new EditarPerfilPage();
            eliminarPerfilPage = new EliminarPerfilPage();
            verDetallePerfilPage = new VerDetallePerfilPage();
        }
        #region CP01_Listar Perfil
        [Given(@"El usuario ingresa a la opción de menú Listar Perfil")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuListarGruposUsuarios()
        {
            listarPerfilPage.IngresarMenuListarPerfilUsuarios();
        }

        [Then(@"El sistema despliega una grilla con los registros de los perfiles existentes en el sistema")]
        public void EntoncesElSistemaDespliegaUnaGrillaConLosRegistrosDeGruposExistentesEnElSistema()
        {
            listarPerfilPage.ValidarCantidadRegistrosGrilla();
        }
        #endregion
        #region CP02_Ingresar Perfil
        [Given(@"El usuario ingresa a la opción de menú Ingresar Perfil")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuIngresarPerfil()
        {
            ingresarPerfilPage.IngresarMenuIngresarPerfil();
        }

        [Given(@"El sistema despliega el formulario para ingresar perfil")]
        public void DadoElSistemaDespliegaElFormularioParaIngresarPerfil()
        {
            Assert.IsTrue(ingresarPerfilPage.ValidarPáginaIngresarPerfil(), "Formulario de ingreso de perfil de usuarios no ha sido cargado");
        }

        [When(@"El usuario ingresa la descripción (.*) y selecciona el grupo (.*)")]
        public void CuandoElUsuarioIngresaLaDescripcionYSeleccionaElGrupo(string Descripcion, string Grupo)
        {
            ingresarPerfilPage.CompletarIngresoPerfil(Descripcion, Grupo);
        }

        [When(@"El usuario pulsa el botón Registrar")]
        public void CuandoElUsuarioPulsaElBotonRegistrar()
        {
            ingresarPerfilPage.PulsarBotonRegistrar();
        }

        [When(@"El usuario confirma el ingreso del registro")]
        public void CuandoElUsuarioConfirmaElIngresoDelRegistro()
        {
            ingresarPerfilPage.PulsarConfirmarCreacion();
            ingresarPerfilPage.PulsarCerrarConfimacion();
        }

        [Then(@"El sistema despliega en la grilla el registro ingresado con la descripción (.*)")]
        public void EntoncesElSistemaDespliegaEnLaGrillaElRegistroIngresadoConLaDescripcion(string Descripcion)
        {
            ingresarPerfilPage.ValidarCreacionRegistroPerfil(Descripcion);
        }
        #endregion
        #region CP03_Editar Perfil
        [Given(@"El usuario pulsa el botón Editar para el registro con descripción (.*)")]
        public void DadoElUsuarioPulsaElBotonEditarParaElRegistroConDescripcion(string DescripcionSearch)
        {
            editarPerfilPage.PulsarBotonEditarPerfil(DescripcionSearch);
        }

        [Given(@"El sistema despliega el formulario para editar perfil y con la siguiente información: descripción (.*), grupo (.*)")]
        public void DadoElSistemaDespliegaElFormularioParaEditarPerfilYConLaSiguienteInformacionDescripcionGrupo(string DescripcionSearch, string GrupoSearch)
        {
            editarPerfilPage.ValidarPáginaEditarPerfil();
            editarPerfilPage.ValidarInformacionDesplegada(DescripcionSearch);
        }

        [When(@"El usuario modifica la descripción por (.*) y selecciona el grupo (.*)")]
        public void CuandoElUsuarioModificaLaDescripcionPorYSeleccionaElGrupo(string DescripcionEdit, string GrupoEdit)
        {
            editarPerfilPage.EditarPerfil(DescripcionEdit, GrupoEdit);
        }

        [When(@"El usuario pulsa el botón Editar")]
        public void CuandoElUsuarioPulsaElBotonEditar()
        {
            editarPerfilPage.PulsarBotonEditar();
        }

        [When(@"El usuario confirma a edición del registro")]
        public void CuandoElUsuarioConfirmaAEdicionDelRegistro()
        {
            editarPerfilPage.PulsarConfirmarEdicion();
            editarPerfilPage.PulsarCerrarConfimacion();
        }

        [Then(@"El sistema despliega en la grilla el registro modificado con la descripción (.*)")]
        public void EntoncesElSistemaDespliegaEnLaGrillaElRegistroModificadoConLaDescripcion(string DescripcionEdit)
        {
            editarPerfilPage.ValidarEdicionRegistroPerfil(DescripcionEdit);
        }

        #endregion
        #region CP04_Eliminar Perfil
        [Given(@"El usuario pulsa el botón Eliminar para el registro con descripción (.*)")]
        public void DadoElUsuarioPulsaElBotonEliminarParaElRegistroConDescripcion(string DescripcionSearch)
        {
            eliminarPerfilPage.PulsarBotonEliminarPerfil(DescripcionSearch);
        }

        [Given(@"El sistema despliega formulario con los campos Descripción y Grupo en modo sólo lectura, y con la siguiente información: (.*), (.*)")]
        public void DadoElSistemaDespliegaFormularioConLosCamposDescripcionYGrupoEnModoSoloLecturaYConLaSiguienteInformacion(string DescripcionSearch, string Grupo)
        {
            eliminarPerfilPage.ValidarDespliegueEliminarPerfil();
            eliminarPerfilPage.ValidarCamposDetallePerfil();
            eliminarPerfilPage.ValidarInformacionDesplegada(DescripcionSearch);
        }

        [When(@"El usuario pulsa el botón Eliminar")]
        public void CuandoElUsuarioPulsaElBotonEliminar()
        {
            eliminarPerfilPage.PulsarBotonEliminar();
        }

        [When(@"El usuario confirma la eliminación del registro")]
        public void CuandoElUsuarioConfirmaLaEliminacionDelRegistro()
        {
            eliminarPerfilPage.PulsarConfirmarEliminacion();
            eliminarPerfilPage.PulsarCerrarConfimacion();
        }

        [Then(@"El sistema no despliega en la grilla el registro con la descripción (.*)")]
        public void EntoncesElSistemaNoDespliegaEnLaGrillaElRegistroConLaDescripcion(string DescripcionSearch)
        {
            eliminarPerfilPage.ValidarEliminacionRegistroPerfil(DescripcionSearch);
        }
        #endregion
        #region CP05_Ver Detalle Perfil
        [When(@"El usuario pulsa el botón Detalle para el registro con descripción (.*)")]
        public void CuandoElUsuarioPulsaElBotonDetalleParaElRegistroConDescripcion(string DescripcionSearch)
        {
            verDetallePerfilPage.VerDetallePerfil(DescripcionSearch);
        }

        [Then(@"El sistema despliega un modal con los campos Descripción y Grupo en modo sólo lectura, y con la siguiente información: (.*), (.*)")]
        public void EntoncesElSistemaDespliegaUnModalConLosCamposDescripcionYGrupoEnModoSoloLecturaYConLaSiguienteInformacion(string DescripcionSearch, string Grupo)
        {
            verDetallePerfilPage.ValidarDespliegueModalDetallePerfil();
            verDetallePerfilPage.ValidarCamposDetallePerfil();
            verDetallePerfilPage.ValidarInformacionDesplegada(DescripcionSearch);
            verDetallePerfilPage.CerrarModalDetallePerfil();
        }

        #endregion

    }
}
