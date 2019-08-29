using NUnit.Framework;
using AutomatizacionScoleg.Pages.M01_Transversal;
using System;
using TechTalk.SpecFlow;

namespace AutomatizacionScoleg.Steps.M01_Transversal
{
    [Binding]
    public class M01Transversal_S01SesionSteps
    {
        //Establecer objeto clase S1_SesionSteps
        private static LoginPage loginPage;

        //Constructor de la clase
        public M01Transversal_S01SesionSteps()
        {
            loginPage = new LoginPage();
        }

        [Given(@"El sistema despliega formulario de inicio de sesión")]
        public void ValidarDesplieguePaginaLogin()
        {
            Assert.IsTrue(loginPage.ValidarDespliegueLogin(), "Página de inicio de sesión no ha sido cargada");
        }

        [When(@"El usuario ingresa el Rut (.*) y Password (.*)")]
        public void CompletarFormularioInicioDeSesion(string RutUsuario, string Password)
        {
            loginPage.CompletarFormularioInicioSesion(RutUsuario, Password);
        }

        [When(@"El usuario pulsa el botón Log In")]
        public void PulsarBotonLogIn()
        {
            loginPage.PulsarBotonLogIn();
        }

        [Then(@"El sistema despliega página principal del sitio Legal Partner")]
        public void DesplegarPaginaPrincipal()
        {
            loginPage.ValidarDesplieguePaginaPrincipal();
        }

        [Given(@"El usuario pulsa el botón Cerrar Sesión")]
        public void PulsarElBotonCerrarSesion()
        {
            loginPage.PulsarBotonCerrarSesion();
        }

        [When(@"El usuario confirma el cierre de sesión")]
        public void ConfirmarCierreDeSesion()
        {
            loginPage.PulsarBotonConfirmarCerrarSesion();
        }

        [Then(@"El sistema despliega formulario de inicio de sesión")]
        public void DesplegarFormularioInicioSesion()
        {
            Assert.IsTrue(loginPage.ValidarDespliegueLogin(), "Página de inicio de sesión no ha sido cargada");
        }


    }
}