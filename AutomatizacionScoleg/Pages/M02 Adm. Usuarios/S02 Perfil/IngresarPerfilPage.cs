using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using System.Collections.Generic;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S02_Perfil
{
    public class IngresarPerfilPage : BasePage
    {
        public IngresarPerfilPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.Id, Using = "select2-GrupoCodigo-container")]
        public IWebElement ddlGrupo;

        [FindsBy(How = How.Id, Using = "btn-registrar")]
        public IWebElement btnRegistrar;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmarCreacion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;

        #endregion

        /// <summary>
        /// Seleccionar opción de menú ingresar grupo usuarios
        /// </summary>
        public void IngresarMenuIngresarPerfil()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MoveToElement(elementosMenu.SubMenuPerfilUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuIngresarPerfilUsuarios);
        }


        /// <summary>
        /// Verificar la carga de la página para ingreso de grupo usuario
        /// </summary>
        public bool ValidarPáginaIngresarPerfil()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        /// <summary>
        /// Completar información ingreso de perfil
        /// </summary>
        public void CompletarIngresoPerfil(string Descripcion, string Grupo)
        {
            ClearAndSendKeys(txtDescripcion, Descripcion);
            WaitAndClickElement(ddlGrupo);
            SelectOptionDropDown("li[class*='select2-results__option'", Grupo);
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
        /// Verificar creación de perfil
        /// </summary>
        public void ValidarCreacionRegistroPerfil(string Descripcion)
        {
            FindValueInGrid(Descripcion, "example");
        }

    }
}
