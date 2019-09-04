using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomatizacionScoleg.Pages.M01_Transversal
{
    /// <summary>
    /// Elementos Web del Login.
    /// </summary>
    public class LoginPage : BasePage
    {
        //Constructor de la clase
        public LoginPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "Rut")]
        public IWebElement txtRutUsuario;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "btn-login")]
        public IWebElement btnLogin;

        [FindsBy(How = How.Id, Using = "btn-cerrar-session")]
        public IWebElement btnCerrarSesion;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-cerrar-session")]
        public IWebElement btnConfirmarCerrarSesion;

        #endregion

        /// <summary>
        /// Verificar la carga de la página de login.
        /// </summary>
        /// <returns><c>true</c> página cargada <c>false</c> página no cargada </returns>
        public bool ValidarDespliegueLogin()
        {
            System.Threading.Thread.Sleep(2000);
            return IsElementDisplayed(txtRutUsuario);
        }

        /// <summary>
        /// Completar información login
        /// </summary>
        public void CompletarFormularioInicioSesion(string RutUsuario, string Password)
        {
            ClearAndSendKeys(txtRutUsuario, RutUsuario);
            ClearAndSendKeys(txtPassword, Password);
        }


        /// <summary>
        /// Pulsar botón LogIn
        /// </summary>
        public void PulsarBotonLogIn()
        {
            WaitAndClickElement(btnLogin);
        }

        /// <summary>
        /// Verificar despliegue página principal
        /// </summary>
        /// <returns><c>true</c> página cargada <c>false</c> página no cargada </returns>
        public void ValidarDesplieguePaginaPrincipal()
        {
            WaitAndClickElement(btnCerrarSesion);
            WaitAndClickElement(btnConfirmarCerrarSesion);
        }

        /// <summary>
        /// Pulsar botón Cerrar Sesión
        /// </summary>
        public void PulsarBotonCerrarSesion()
        {
            string RutUsuario = ParametrosEjecucion.Usuario;
            string Password = ParametrosEjecucion.Password;

            if (GetBrowserUrl() == ParametrosEjecucion.RutaDelSitio + "/")
            {
                System.Threading.Thread.Sleep(2000);
                ClearAndSendKeys(txtRutUsuario, RutUsuario);
                ClearAndSendKeys(txtPassword, Password);
                WaitAndClickElement(btnLogin);
                WaitAndClickElement(btnCerrarSesion);
            }
            else
            {
                WaitAndClickElement(btnCerrarSesion);
            }

        }

        /// <summary>
        /// Confirmar cierre de sesión
        /// </summary>
        public void PulsarBotonConfirmarCerrarSesion()
        {
            WaitAndClickElement(btnConfirmarCerrarSesion);
        }

    }
}
