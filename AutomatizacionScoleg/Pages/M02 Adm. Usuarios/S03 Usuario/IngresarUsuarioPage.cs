using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using System;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S03_Usuario
{
    public class IngresarUsuarioPage : BasePage
    {
        //Constructor de la clase
        public IngresarUsuarioPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "RutUsuario")]
        public IWebElement txtRutUsuario;

        [FindsBy(How = How.Id, Using = "Nombre")]
        public IWebElement txtNombreUsuario;

        [FindsBy(How = How.Id, Using = "ApellidoPaterno")]
        public IWebElement txtApellidoPaternoUsuario;

        [FindsBy(How = How.Id, Using = "ApellidoMaterno")]
        public IWebElement txtApellidoMaternoUsuario;

        [FindsBy(How = How.Id, Using = "SesionUsuario")]
        public IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "Contraseña")]
        public IWebElement txtContrasena;

        [FindsBy(How = How.Id, Using = "ContraseñaConfirmacion")]
        public IWebElement txtContrasenaConfirmacion;

        [FindsBy(How = How.Id, Using = "Telefono")]
        public IWebElement txtTelefono;

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "select2-IdSucursal-container")]
        public IWebElement ddlSucursal;

        [FindsBy(How = How.Id, Using = "select2-CodigoPerfil-container")]
        public IWebElement ddlPerfil;

        [FindsBy(How = How.Id, Using = "btn-buscar")]
        public IWebElement btnBuscar;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarModalErrorRut;

        [FindsBy(How = How.Id, Using = "btn-registrar")]
        public IWebElement btnRegistrar;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmarCreacion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;
        #endregion

        /// <summary>
        /// Seleccionar opción de menú ingresar usuarios
        /// </summary>
        public void IngresarMenuIngresarUsuarios()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MoveToElement(elementosMenu.SubMenuUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuIngresarUsuarios);
        }

        /// <summary>
        /// Verificar la carga de la página para ingreso de grupo usuario
        /// </summary>
        public bool ValidarPáginaIngresarUsuario()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtRutUsuario);
        }

        public void IngresarRut(string RutUsuario)
        {
            try
            {
                ClearAndSendKeys(txtRutUsuario, RutUsuario);
                WaitAndClickElement(btnBuscar);
            }
            catch (Exception)
            {

                throw new Exception("Error al ingresar los datos de ingreso de usuario");
            }

        }

        public void CompletarIngresoUsuario(string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Username, string Password, string ConfirmPassword, string telefono, string Email, string Sucursal, string Perfil)
        {
            System.Threading.Thread.Sleep(3000);
            try
            {
                if (IsElementDisplayed(btnCerrarModalErrorRut))
                {
                    WaitAndClickElement(btnCerrarModalErrorRut);

                }
                else
                {
                    ClickElement(txtNombreUsuario);
                    WaitAndClickElement(btnCerrarModalErrorRut);
                }
                System.Threading.Thread.Sleep(3000);

                if (IsElementDisplayed(txtNombreUsuario))
                {
                    ClearAndSendKeys(txtNombreUsuario, Nombre);
                    ClearAndSendKeys(txtApellidoPaternoUsuario, ApellidoPaterno);
                    ClearAndSendKeys(txtApellidoMaternoUsuario, ApellidoMaterno);
                    ClearAndSendKeys(txtUsername, Username);
                    ClearAndSendKeys(txtContrasena, Password);
                    ClearAndSendKeys(txtContrasenaConfirmacion, ConfirmPassword);
                    ClearAndSendKeys(txtTelefono, telefono);
                    ClearAndSendKeys(txtEmail, Email);
                    WaitAndClickElement(ddlSucursal);
                    SelectOptionDropDown("li[class*='select2-results__option'", Sucursal);
                    WaitAndClickElement(ddlPerfil);
                    SelectOptionDropDown("li[class*='select2-results__option'", Perfil);
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al limpiar e introducir valores en el formulario de ingreso de usuario");
            }
        }

        /// <summary>
        /// Pulsar botón Registrar
        /// </summary>
        public void PulsarBotonRegistrar()
        {
            WaitAndClickElement(btnRegistrar);
        }

        /// <summary>
        /// Pulsar botón confirmar creación
        /// </summary>
        public void PulsarConfirmarCreacion()
        {
            WaitAndClickElement(btnConfirmarCreacion);
        }

        /// <summary>
        /// Pulsar botón cerrar confirmación
        /// </summary>
        public void PulsarCerrarConfimacion()
        {
            WaitAndClickElement(btnCerrarConfirmacion);

        }

        /// <summary>
        /// Verificar creación de grupo de usuario
        /// </summary>
        public void ValidarCreacionRegistroGrupoUsuarios(string RutUSuario)
        {
            FindValueInGrid(RutUSuario, "example");
        }

    }
}
