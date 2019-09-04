using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using AutomatizacionScoleg.Utilidades.Steps;

namespace AutomatizacionScoleg.Pages._01._Transversal._01._Acceso
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

        [FindsBy(How = How.Id, Using = "navbarSupportedContent")]
        public IWebElement menuPrincipal;
        #endregion

        /// <summary>
        /// Verificar la carga de la página de login.
        /// </summary>
        /// <returns><c>true</c> página cargada <c>false</c> página no cargada </returns>
        public bool ValidarDespliegueLogin()
        {
            System.Threading.Thread.Sleep(1000);
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
        public bool ValidarDesplieguePaginaPrincipal()
        {
            return IsElementDisplayed(menuPrincipal);

        }

        /// <summary>
        /// Pulsar botón Cerrar Sesión
        /// </summary>
        public void PulsarBotonCerrarSesion()
        {
            WaitAndClickElement(btnCerrarSesion);
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
