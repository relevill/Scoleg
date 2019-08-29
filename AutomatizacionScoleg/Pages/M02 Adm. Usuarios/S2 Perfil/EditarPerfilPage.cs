using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S2_Perfil
{
    public class EditarPerfilPage : BasePage
    {
        public EditarPerfilPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "btnEditar")]
        public IWebElement btnEditarListar;

        [FindsBy(How = How.Id, Using = "btn-editar")]
        public IWebElement btnEditar;

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.Id, Using = "select2-GrupoCodigo-container")]
        public IWebElement ddlGrupo;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnAceptar;

        [FindsBy(How = How.Id, Using = "example_next")]
        public IWebElement btnSiguiente;


        #endregion
        /// <summary>
        /// Ingreso al Listar Perfiles
        /// </summary>

        public void PosicionarListarPerfiles()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MenuPage.PosicionarCursor(elementosMenu.SubMenuPerfiles);
            WaitAndClickElement(elementosMenu.SubSubMenuListarPerfiles);
        }

        /// <summary>
        /// Método que presiona el boton editar de acuerdo a lo mostrado en excel, 
        /// si no se encuentra ningun registro este tomara el primero de la tabla
        /// a modo de probar la funcionalidad. 
        /// </summary>
        /// <param name="DescripcionPerfil"></param>
        public void IngresarEditarPerfiles(string DescripcionPerfil)
        {
            System.Threading.Thread.Sleep(2000);
            try
            {
                bool flag = true;
                var tabla = PropiedadDriver.GetDriver.FindElement(By.Id("example"));
                while (flag == true)
                {
                    foreach (var tr in tabla.FindElements(By.TagName("tr")))
                    {
                        var tds = tr.FindElements(By.TagName("td"));
                        for (var i = 0; i < tds.Count; i++)
                        {
                            if (tds[i].Text.Trim() == DescripcionPerfil.Trim())
                            {
                                tds[i + 2].FindElement(By.Id("btnEditar")).Click();
                                flag = false;
                                return;
                            }

                        }

                    }
                    if (btnSiguiente.GetAttribute("class") == "paginate_button page-item next disabled")
                    {
                        WaitAndClickElement(btnEditarListar);
                        break;
                    }
                    else
                    {
                        WaitAndClickElement(btnSiguiente);
                    }
                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("Error al Seleccionar un Perfil a Editar");
            }
        }
        public bool ValidarPáginaEditarPerfil()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        public void CompletarDescripcionEditar(string DescripcionEditar)
        {
            ClearAndSendKeys(txtDescripcion, DescripcionEditar);
        }
        public void SeleccionarGrupo(string GrupoEditar)
        {
            WaitAndClickElement(ddlGrupo);
            IList<IWebElement> options = PropiedadDriver.GetDriver.FindElements(By.CssSelector("li[class*='select2-results__option']"));
            try
            {
                foreach (IWebElement element in options)
                {
                    if (element.Text.Equals(GrupoEditar))
                    {

                        element.Click();
                        break;
                    }


                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("Error al Seleccionar un Grupo para editar Perfil");
            }


        }


        public void PulsarBotonEditar()
        {
            WaitAndClickElement(btnEditar);
        }

        public void PulsarBotonConfirmar()
        {
            WaitAndClickElement(btnAceptar);
        }


    }
}
