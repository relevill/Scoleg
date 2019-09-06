using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S03_Usuario
{
    public class EditarUsuarioPage : BasePage
    {
        public EditarUsuarioPage()
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

        [FindsBy(How = How.XPath, Using = "//*[@id='example']/tbody/tr/td/input")]
        public IWebElement txtNoSucursal;

        [FindsBy(How = How.Id, Using = "select2-CodigoPerfil-container")]
        public IWebElement ddlPerfil;

        [FindsBy(How = How.Id, Using = "btn-editar")]
        public IWebElement btnEditar;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarModalErrorRut;

        [FindsBy(How = How.Id, Using = "checkSucursal")]
        public IWebElement chkSucursal;
        
        [FindsBy(How = How.Id, Using = "btn-registrar")]
        public IWebElement btnRegistrar;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmarEdicion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;
        #endregion

        public void PulsarBotonEditarUsuario(string RutUsuario)
        {
            ClickElementGrid(RutUsuario, "example", 1, "btnEditar");
        }

        /// <summary>
        /// Verificar la carga de la página para editar grupo usuario
        /// </summary>
        public bool ValidarPáginaEditarUsuario()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtRutUsuario);
        }

        /// <summary>
        /// Modificar información del grupo usuario
        /// </summary>
        public void EditarUsuario(string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Username, string Password, string ConfirmPassword, string telefono, string Email, string Sucursal, string Perfil)
        {
            ClearAndSendKeys(txtNombreUsuario, Nombre);
            ClearAndSendKeys(txtApellidoPaternoUsuario, ApellidoPaterno);
            ClearAndSendKeys(txtApellidoMaternoUsuario, ApellidoMaterno);
            ClearAndSendKeys(txtUsername, Username);
            ClearAndSendKeys(txtContrasena, Password);
            ClearAndSendKeys(txtContrasenaConfirmacion, ConfirmPassword);
            ClearAndSendKeys(txtTelefono, telefono);
            ClearAndSendKeys(txtEmail, Email);
            WaitAndClickElement(ddlPerfil);
            SelectOptionDropDown("li[class*='select2-results__option'", Perfil);
            if (txtNoSucursal.GetCssValue("value")== "El usuario no tiene Sucursales asociadas")
            {

            }
        }

        /// <summary>
        /// Pulsar botón Editar
        /// </summary>
        public void PulsarBotonEditar()
        {
            WaitAndClickElement(btnEditar);
        }

        /// <summary>
        /// Pulsar botón confirmar edición
        /// </summary>
        public void PulsarConfirmarEdicion()
        {
            WaitAndClickElement(btnConfirmarEdicion);
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
        public void ValidarEdicionRegistroGrupoUsuarios(string RutUsuario)
        {
            FindValueInGrid(RutUsuario, "example");
        }
    }
}
