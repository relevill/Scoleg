using AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S01_Grupo;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomatizacionScoleg.Steps.M02_Adm._Usuarios
{

    [Scope(Feature = "M02 Adm. Usuarios_S01 Grupo")]
    [Binding]
    public class M02Adm_Usuarios_S01GrupoSteps
    {
        //Establecer objeto clase S1_SesionSteps
        private static ListarGrupoPage listarGrupoPage;
        private static IngresarGrupoPage ingresarGrupoPage;
        private static EditarGrupoPage editarGrupoPage;
        private static EliminarGrupoPage eliminarGrupoPage;
        private static VerDetalleGrupoPage verDetalleGrupoPage;

        //Constructor de la clase
        public M02Adm_Usuarios_S01GrupoSteps()
        {
            listarGrupoPage = new ListarGrupoPage();
            ingresarGrupoPage = new IngresarGrupoPage();
            editarGrupoPage = new EditarGrupoPage();
            eliminarGrupoPage = new EliminarGrupoPage();
            verDetalleGrupoPage = new VerDetalleGrupoPage();
        }

        #region CP01_Listar Grupo
        [Given(@"El usuario ingresa a la opción de menú Listar Grupos Usuarios")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuListarGruposUsuarios()
        {
            listarGrupoPage.IngresarMenuListarGruposUsuarios();
        }

        [Then(@"El sistema despliega una grilla con los registros de grupos existentes en el sistema")]
        public void EntoncesElSistemaDespliegaUnaGrillaConLosRegistrosDeGruposExistentesEnElSistema()
        {
            listarGrupoPage.ValidarCantidadRegistrosGrilla();
        }
        #endregion

        #region CP02_Ingresar Grupo
        [Given(@"El usuario ingresa a la opción de menú Ingresar Grupo Usuarios")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuIngresarGrupoUsuarios()
        {
            ingresarGrupoPage.IngresarMenuIngresarGrupoUsuarios();
        }

        [Given(@"El sistema despliega el formulario para ingresar grupo")]
        public void DadoElSistemaDespliegaElFormularioParaIngresarGrupo()
        {
            Assert.IsTrue(ingresarGrupoPage.ValidarPáginaIngresarGrupo(), "Formulario de ingreso de grupo de usuarios no ha sido cargado");
        }

        [When(@"El usuario ingresa la descripción (.*) y selecciona el módulo (.*)")]
        public void CuandoElUsuarioIngresaLaDescripcionYSeleccionaElModulo(string Descripcion, string Modulos)
        {
            ingresarGrupoPage.CompletarIngresoGrupo(Descripcion, Modulos);
        }

        [When(@"El usuario pulsa el botón Registrar")]
        public void CuandoElUsuarioPulsaElBotonRegistrar()
        {
            ingresarGrupoPage.PulsarBotonRegistrar();
        }

        [When(@"El usuario confirma el ingreso del registro")]
        public void CuandoElUsuarioConfirmaElIngresoDelRegistro()
        {
            ingresarGrupoPage.PulsarConfirmarCreacion();
            ingresarGrupoPage.PulsarCerrarConfimacion();
        }

        [Then(@"El sistema despliega en la grilla el registro ingresado con la descripción (.*)")]
        public void EntoncesElSistemaListaElRegistroConLaDescripcionIngresada(string Descripcion)
        {
            ingresarGrupoPage.ValidarCreacionRegistroGrupoUsuarios(Descripcion);
        }
        #endregion

        #region CP03_Editar Grupo
        [Given(@"El usuario pulsa el botón Detalle para el registro con descripción (.*)")]
        public void DadoElUsuarioPulsaElBotonDetalleParaElRegistroConDescripcion(string DescripcionSearch)
        {
            editarGrupoPage.PulsarBotonEditarGrupo(DescripcionSearch);
        }

        [Given(@"El sistema despliega el formulario para editar grupo y con la siguiente información: descripción (.*), Módulos (.*)")]
        public void DadoElSistemaDespliegaElFormularioParaEditarGrupoYConLaSiguienteInformacionDescripcionModulos(string DescripcionSearch, string ModulosSearch)
        {
            editarGrupoPage.ValidarPáginaEditarGrupo();
            editarGrupoPage.ValidarInformacionDesplegada(DescripcionSearch);
        }


        [When(@"El usuario modifica la descripción por (.*) y selecciona el módulo (.*)")]
        public void CuandoElUsuarioModificaLaDescripcionPorYSeleccionaElModulo(string DescripcionEdit, string ModulosEdit)
        {
            editarGrupoPage.EditarGrupo(DescripcionEdit, ModulosEdit);
        }

        [When(@"El usuario pulsa el botón Editar")]
        public void CuandoElUsuarioPulsaElBotonEditar()
        {
            editarGrupoPage.PulsarBotonEditar();
        }

        [When(@"El usuario confirma a edición del registro")]
        public void CuandoElUsuarioConfirmaAEdicionDelRegistro()
        {
            editarGrupoPage.PulsarConfirmarEdicion();
            editarGrupoPage.PulsarCerrarConfimacion();
        }

        [Then(@"El sistema despliega en la grilla el registro modificado con la descripción (.*)")]
        public void EntoncesElSistemaListaEnLaGrillaElRegistroModificadoConLaDescripcion(string DescripcionEdit)
        {
            editarGrupoPage.ValidarEdicionRegistroGrupoUsuarios(DescripcionEdit);
        }
        #endregion

        #region CP04_Eliminar Grupo
        [Given(@"El usuario pulsa el botón Eliminar para el registro con descripción (.*)")]
        public void DadoElUsuarioPulsaElBotonEliminarParaElRegistroConDescripcion(string DescripcionSearch)
        {
            eliminarGrupoPage.PulsarBotonEliminarGrupo(DescripcionSearch);
        }

        [Given(@"El sistema despliega formulario con los campos Descripción y Módulos en modo sólo lectura, y con la siguiente información: (.*), (.*)")]
        public void DadoElSistemaDespliegaFormularioConLosCamposDescripcionYModulosEnModoSoloLecturaYConLaSiguienteInformacion(string DescripcionSearch, string Modulos)
        {
            eliminarGrupoPage.ValidarDespliegueEliminarGrupo();
            eliminarGrupoPage.ValidarCamposDetalleGrupo();
            eliminarGrupoPage.ValidarInformacionDesplegada(DescripcionSearch);
        }

        [When(@"El usuario pulsa el botón Eliminar")]
        public void CuandoElUsuarioPulsaElBotonEliminar()
        {
            eliminarGrupoPage.PulsarBotonEliminar();
        }

        [When(@"El usuario confirma la eliminación del registro")]
        public void CuandoElUsuarioConfirmaLaEliminacionDelRegistro()
        {
            eliminarGrupoPage.PulsarConfirmarEliminacion();
            eliminarGrupoPage.PulsarCerrarConfimacion();
        }

        [Then(@"El sistema no despliega en la grilla el registro con la descripción (.*)")]
        public void EntoncesElSistemaEliminaDeLaGrillaElRegistroConLaDescripcion(string DescripcionSearch)
        {
            eliminarGrupoPage.ValidarEliminacionRegistroGrupoUsuarios(DescripcionSearch);
        }
        #endregion

        #region CP05_Ver Detalle Grupo
        [When(@"El usuario pulsa el botón Detalle para el registro con descripción (.*)")]
        public void CuandoElUsuarioPulsaElBotonDetalleParaElRegistroConDescripcion(string DescripcionSearch)
        {
            verDetalleGrupoPage.VerDetalleGrupo(DescripcionSearch);
        }

        [Then(@"El sistema despliega un modal con los campos Descripción y Módulos en modo sólo lectura, y con la siguiente información: (.*), (.*)")]
        public void EntoncesElSistemaDespliegaModalConLosCamposDescripcionYModulosEnModoSoloLecturaYConLaSiguienteInformacion(string DescripcionSearch, string Modulos)
        {
            verDetalleGrupoPage.ValidarDespliegueModalDetalleGrupo();
            verDetalleGrupoPage.ValidarCamposDetalleGrupo();
            verDetalleGrupoPage.ValidarInformacionDesplegada(DescripcionSearch);
            verDetalleGrupoPage.CerrarModalDetalleGrupoUsuario();
        }
        #endregion
    }
}