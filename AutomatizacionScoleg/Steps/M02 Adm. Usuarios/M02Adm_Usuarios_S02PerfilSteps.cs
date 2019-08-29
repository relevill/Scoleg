using AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S2_Perfil;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomatizacionScoleg.Steps.M02_Adm._Usuarios
{
    //[Scope(Feature = "M02 Adm. Usuarios_S02 Perfiles")]
    [Binding]
    public class M02Adm_Usuarios_S02PerfilSteps
    {
        #region ConnectionString
        string vConnectionSting = @"Data Source=172.17.206.19;Initial Catalog=LS_SZ_2;Persist Security Info=False;User ID=admin; Password=Indra.2018";
        #endregion

        #region Query Listar Perfiles
        string vQuery = "select * from LS_TIP_PERFIL;";
        #endregion

        //Establecer objeto clase S1_SesionSteps
        private static IngresarPerfilPage ingresarPerfilPage;
        private static EditarPerfilPage editarPerfilPage;
        private static VerDetallePerfilPage verDetallePerfilPage;
        private static EliminarPerfilPage eliminarPerfilPage;
        private static ListarPerfilPage listarPerfilPage;

        //Constructor de la clase
        public M02Adm_Usuarios_S02PerfilSteps()
        {
            ingresarPerfilPage = new IngresarPerfilPage();
            editarPerfilPage = new EditarPerfilPage();
            verDetallePerfilPage = new VerDetallePerfilPage();
            eliminarPerfilPage = new EliminarPerfilPage();
            listarPerfilPage = new ListarPerfilPage();
        }

        #region Ingresar Perfil

        [Given(@"El usuario ingresa a la opción de menú Perfiles")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuPerfiles()
        {
            ingresarPerfilPage.IngresarMenuIngresarPerfil();
        }

        [Given(@"El sistema despliega el formulario para ingresar perfil")]
        public void DadoElSistemaDespliegaElFormularioParaIngresarPerfil()
        {
            Assert.IsTrue(ingresarPerfilPage.ValidarPáginaIngresarPerfil(), "Formulario de ingreso de grupo de usuarios no ha sido cargado");
        }

        [When(@"El usuario selecciona un (.*) en el campo Grupo de Perfil")]
        public void CuandoElUsuarioSeleccionaUnEnElCampoGrupoDePerfil(string GrupoPerfil)
        {
            ingresarPerfilPage.SeleccionarGrupo(GrupoPerfil);
        }

        [When(@"El usuario pulsa el botón Registrar nuevo perfil")]
        public void CuandoElUsuarioPulsaElBotonRegistrarNuevoPerfil()
        {
            ingresarPerfilPage.PulsarBotonRegistrar();
        }

        [When(@"El usuario confirma el ingreso del registro de nuevo perfil")]
        public void CuandoElUsuarioConfirmaElIngresoDelRegistroDeNuevoPerfil()
        {
            ingresarPerfilPage.PulsarBotonConfirmar();
        }

        [Then(@"El sistema crea el nuevo Perfil")]
        public void EntoncesElSistemaCreaElNuevoPerfil()
        {
            ingresarPerfilPage.PulsarBotonCerrar();
        }
        #endregion

        #region Editar Perfil
        [Given(@"El usuario ingresa a la opcion de menú Listar Perfiles")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuListarPerfiles()
        {
            editarPerfilPage.PosicionarListarPerfiles();
        }

        [Given(@"El usuario presiona el botón editar según (.*) de la lista")]
        public void DadoElUsuarioPresionaElBotonEditarSegunDeLaLista(string DescripcionPerfil)
        {
            editarPerfilPage.IngresarEditarPerfiles(DescripcionPerfil);
        }

        [Given(@"El sistema despliega el formulario para editar un perfil")]
        public void DadoElSistemaDespliegaElFormularioParaEditarUnPerfil()
        {
            Assert.IsTrue(editarPerfilPage.ValidarPáginaEditarPerfil(), "Formulario de modificación de perfil no ha sido cargado");
        }

        [When(@"El usuario edita (.*) en el campo Descripcion Perfil")]
        public void CuandoElUsuarioEditaEnElCampoDescripcionPerfil(string DescripcionEditar)
        {
            editarPerfilPage.CompletarDescripcionEditar(DescripcionEditar);
        }

        [When(@"El usuario cambia un (.*) del campo Grupo de Perfil")]
        public void CuandoElUsuarioCambiaUnDelCampoGrupoDePerfil(string GrupoEditar)
        {
            editarPerfilPage.SeleccionarGrupo(GrupoEditar);
        }

        [When(@"El usuario pulsa el boton Editar nuevo perfil")]
        public void CuandoElUsuarioPulsaElBotonEditarNuevoPerfil()
        {
            editarPerfilPage.PulsarBotonEditar();
        }

        [Then(@"El usuario confirma la modificacion del perfil")]
        public void EntoncesElUsuarioConfirmaLaModificacionDelPerfil()
        {
            editarPerfilPage.PulsarBotonConfirmar();
        }


        #endregion

        #region Ver Detalle Perfil
        [Given(@"El usuario ingresa a la opcion del menu Listar Perfiles")]
        public void DadoElUsuarioIngresaALaOpcionDelMenuListarPerfiles()
        {
            verDetallePerfilPage.PosicionarListarPerfiles();
        }

        [When(@"El usuario presiona el boton Ver Detalle según (.*) y (.*) de la lista")]
        public void CuandoElUsuarioPresionaElBotonVerDetalleSegunYDeLaLista(string DescripcionPerfil, string GrupoPerfil)
        {
            verDetallePerfilPage.VerDetallePerfil(DescripcionPerfil, GrupoPerfil);
        }

        [When(@"El usuario verifica los elementos mostrados (.*) y (.*)")]
        public void CuandoElUsuarioVerificaLosElementosMostradosY(string DescripcionPerfil, string GrupoPerfil)
        {
            verDetallePerfilPage.verificarCantidadElementos();
            verDetallePerfilPage.VerificarElementos(DescripcionPerfil, GrupoPerfil);

        }

        [Then(@"El sistema cierra la ventana modal detalle registro")]
        public void EntoncesElSistemaCierraLaVentanaModalDetalleRegistro()
        {
            verDetallePerfilPage.CerrarVentana();
        }


        #endregion

        #region Eliminar Perfil

        [Given(@"El usuario ingresa a la opcion del menú Listar Perfiles")]
        public void DadoElUsuarioIngresaALaOpcionDelMenuListarPerfilesParaEliminar()
        {
            eliminarPerfilPage.PosicionarListarPerfiles();
        }

        [When(@"El usuario presiona el botón Eliminar según (.*) y (.*) de la lista")]
        public void CuandoElUsuarioPresionaElBotonEliminarSegunYDeLaLista(string DescripcionPerfil, string GrupoPerfil)
        {
            eliminarPerfilPage.EliminarPerfil(DescripcionPerfil, GrupoPerfil);
        }

        [When(@"El usuario presiona boton Eliminar")]
        public void CuandoElUsuarioPresionaBotonEliminar()
        {
            eliminarPerfilPage.EliminarRegistro();
        }


        [When(@"El usuario confirma la eliminación del registro")]
        public void CuandoElUsuarioConfirmaLaEliminacionDelRegistro()
        {
            eliminarPerfilPage.ConfirmarEliminar();
        }

        [Then(@"El sistema muestra la confirmación y el usuario cierra la ventana")]
        public void EntoncesElSistemaMuestraLaConfirmacionYElUsuarioCierraLaVentana()
        {
            eliminarPerfilPage.CerrarModal();
        }

        #endregion

        #region Listar Perfil
        [Given(@"El usuario selecciona la opción del menú Listar Perfiles")]
        public void DadoElUsuarioSeleccionaLaOpcionDelMenuListarPerfiles()
        {
            listarPerfilPage.IngresarMenuListarPerfil();
        }

        [Then(@"El sistema despliegue una grilla con los registros de perfiles existentes en el sistema")]
        public void EntoncesElSistemaDespliegueUnaGrillaConLosRegistrosDePerfilesExistentesEnElSistema()
        {
            //listarPerfilPage.GetQueryResult(vConnectionSting, vQuery);
            //listarPerfilPage.ContarFilas();

            var  filasBD = listarPerfilPage.GetQueryResult(vConnectionSting, vQuery);
            var filas = listarPerfilPage.ContarFilas();

            if (filasBD != filas) //Cambiar operacion cuando el sistema despliegue la misma cantidad de registros
            {
                return;
            }
            else
            {
                throw new Exception("Error en el despliegue de registros... Filas mostradas: " + filas + "Registro BBDD: "+ filasBD);
            }

        }


        #endregion
    }
}


