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
    public class EliminarPerfilPage : BasePage
    {
        public EliminarPerfilPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "btn-eliminar")]
        public IWebElement btnEliminar;

        [FindsBy(How = How.Id, Using = "btnEliminar")]
        public IWebElement btnEliminarListar;

        [FindsBy(How = How.Id, Using = "example_next")]
        public IWebElement btnSiguiente;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmar;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrar;

       
        #endregion

        public void PosicionarListarPerfiles()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MenuPage.PosicionarCursor(elementosMenu.SubMenuPerfiles);
            WaitAndClickElement(elementosMenu.SubSubMenuListarPerfiles);
        }

        public void EliminarPerfil(string DescripcionPerfil, string GrupoPerfil)
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
                            if (tds[i].Text.Trim() == DescripcionPerfil.Trim() && tds[i + 1].Text.Trim() == GrupoPerfil.Trim())
                            {
                                tds[i + 2].FindElement(By.Id("btnEliminar")).Click();
                                flag = false;
                                return;
                            }

                        }

                    }
                    if (btnSiguiente.GetAttribute("class") == "paginate_button page-item next disabled")
                    {
                        WaitAndClickElement(btnEliminarListar);
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
                throw new ExcepcionPrueba("Error al Eliminar un Perfil");
            }
        }
        public void EliminarRegistro()
        {
            WaitAndClickElement(btnEliminar);
        }
        public void ConfirmarEliminar()
        {
            WaitAndClickElement(btnConfirmar);
        }

        public void CerrarModal()
        {
            WaitAndClickElement(btnCerrar);
        }
        
    }
}
