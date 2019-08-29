using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S2_Perfil
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
        public IWebElement btnAceptar;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrar;

        #endregion


        /// <summary>
        /// Seleccionar opción de menú ingresar grupo usuarios
        /// </summary>
        public void IngresarMenuIngresarPerfil()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MenuPage.PosicionarCursor(elementosMenu.SubMenuPerfiles);
            WaitAndClickElement(elementosMenu.SubSubMenuIngresarPerfil);
        }

        /// <summary>
        /// Verificar la carga de la página para ingreso de un perfil
        /// </summary>
        /// <returns><c>true</c> página cargada <c>false</c> página no cargada </returns>
        public bool ValidarPáginaIngresarPerfil()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        /// <summary>
        /// Completar información de ingreso de perfil
        /// </summary>
        public void IngresarCampoDescripcion(string DescripcionPerfil)
        {
            ClearAndSendKeys(txtDescripcion, DescripcionPerfil);
        }

        /// <summary>
        /// Selecciona un valor en el campo Grupo
        /// </summary>
        
        public void SeleccionarGrupo(string GrupoPerfil)
        {
            WaitAndClickElement(ddlGrupo);
            IList<IWebElement> options = PropiedadDriver.GetDriver.FindElements(By.CssSelector("li[class*='select2-results__option']"));
            try
            {
                foreach (IWebElement element in options)
                {
                    if (element.Text.Equals(GrupoPerfil))
                    {

                        element.Click();
                        break;
                    }


                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba ("Error al Seleccionar un Grupo para ingresar Perfil");
            }


        }
        public void PulsarBotonRegistrar()
        {
            WaitAndClickElement(btnRegistrar);
        }

        public void PulsarBotonConfirmar()
        {
            WaitAndClickElement(btnAceptar);
        }
        
        public void PulsarBotonCerrar()
        {
            WaitAndClickElement(btnCerrar);
        }
    }
}
