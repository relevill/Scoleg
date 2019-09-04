using AutomatizacionScoleg.Pages._02._Administrador._01._Administrador_de_Usuarios;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ScolegBDD.Steps._02._Administrador._01._Administrador_de_Usuarios
{
    [Binding]
    public class S02_GrupoSteps
    {
        //Establecer objeto clase S1_SesionSteps
        private static IngresarGrupoPage ingresarGrupoPage;

        //Constructor de la clase
        public S02_GrupoSteps()
        {
            ingresarGrupoPage = new IngresarGrupoPage();
        }

        [Given(@"El usuario ingresa a la opción de menú ingresar grupo usuarios")]
        public void DadoElUsuarioIngresaALaOpcionDeMenuIngresarGrupoUsuarios()
        {
            ingresarGrupoPage.IngresarMenuIngresarGrupoUsuarios();
        }

        [Given(@"El sistema despliega formulario para ingresar grupo")]
        public void DadoElSistemaDespliegaFormularioParaIngresarGrupo()
        {
            Assert.IsTrue(ingresarGrupoPage.ValidarPáginaIngresarGrupo(), "Formulario de ingreso de grupo de suuarios no ha sido cargado");
        }

        [When(@"El usuario completa el campo (.*)")]
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

        [Then(@"El sistema crea el registro exitosamente")]
        public void EntoncesElSistemaCreaElRegistroExitosamente()
        {
            ingresarGrupoPage.ValidarCreacionRegistroGrupoUsuarios();
        }
    }
}
