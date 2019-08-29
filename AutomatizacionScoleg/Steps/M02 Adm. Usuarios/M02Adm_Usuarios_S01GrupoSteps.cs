using AutomatizacionScoleg.Pages.M02_Adm._Usuarios;
using AutomatizacionScoleg.Utilidades.Steps;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomatizacionScoleg.Steps.M02_Adm._Usuarios
{
    [Binding]
    public class M02Adm_Usuarios_S01GrupoSteps
    {
        //Establecer objeto clase S1_SesionSteps
        private static IngresarGrupoPage ingresarGrupoPage;

        private static EditarGrupoPage editarGrupoPage;

        //Constructor de la clase
        public M02Adm_Usuarios_S01GrupoSteps()
        {
            ingresarGrupoPage = new IngresarGrupoPage();
            editarGrupoPage = new EditarGrupoPage();
        }
        #region Ingresar Grupo de Usuarios


        [Given(@"El usuario ingresa a la opción de menú Ingresar Grupo Usuarios")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuIngresarGrupoUsuarios()
        {
            ingresarGrupoPage.IngresarMenuIngresarGrupoUsuarios();
        }

        [Given(@"El sistema despliega el formulario para ingresar grupo")]
        public void DadoElSistemaDespliegaFormularioParaIngresarGrupo()
        {
            Assert.IsTrue(ingresarGrupoPage.ValidarPáginaIngresarGrupo(), "Formulario de ingreso de grupo de usuarios no ha sido cargado");
        }

        [When(@"El usuario ingresa (.*) en el campo Descripción")]
        public void CompletarFormularioInicioDeSesion(string Descripcion)
        {
            ingresarGrupoPage.CompletarIngresoGrupo(Descripcion);
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

        [Then(@"El sistema crea el grupo de usuarios")]
        public void EntoncesElSistemaCreaElRegistroExitosamente(string Descripcion)
        {
            ingresarGrupoPage.ValidarCreacionRegistroGrupoUsuarios(Descripcion);
        }
        #endregion

        #region Editar Grupo de Usuarios

        [Given(@"El sistema despliega la lista de Grupos de Usuarios")]
        public void DadoElSistemaDespliegaLaListaDeGruposDeUsuarios(string Descripcion)
        {
            BaseStep.IniciarSesion();
            editarGrupoPage.PosicionarListar();
            editarGrupoPage.IngresarEditarGrupoUsuarios(Descripcion);
        }

        [When(@"El usuario edita (.*) en el campo Descripción")]
        public void CuandoElUsuarioEditaEnElCampoDescripcion(string DescripcionModificar)
        {
            editarGrupoPage.IngresarEditarGrupoUsuarios(DescripcionModificar);
        }

        [When(@"El usuario pulsa el botón Editar")]
        public void CuandoElUsuarioPulsaElBotonEditar()
        {
            editarGrupoPage.PulsarBotonEditar();
        }

        [When(@"El usuario confirma la modificación del registro")]
        public void CuandoElUsuarioConfirmaLaModificacionDelRegistro()
        {
            editarGrupoPage.PulsarBotonConfirmar();
        }


        //Caso de uso con defecto vigente, al momento de cerrarlo modificar id boton.
        [Then(@"El sistema modifica el grupo de usuarios")]
        public void EntoncesElSistemaModificaElGrupoDeUsuarios()
        {
            editarGrupoPage.PulsarBotonCerrar();
        }

        #endregion
    }
}
