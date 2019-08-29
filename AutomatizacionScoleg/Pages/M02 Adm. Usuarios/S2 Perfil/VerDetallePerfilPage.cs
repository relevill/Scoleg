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
    public class VerDetallePerfilPage : BasePage
    {
        public VerDetallePerfilPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "btnDetalle")]
        public IWebElement btnVerDetalle;

        [FindsBy(How = How.Id, Using = "example_next")]
        public IWebElement btnSiguiente;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-detalle")]
        public IWebElement btnCerrar;

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.Id, Using = "GrupoDescripcion")]
        public IWebElement txtGrupoDescripcion;
        #endregion


        public void PosicionarListarPerfiles()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MenuPage.PosicionarCursor(elementosMenu.SubMenuPerfiles);
            WaitAndClickElement(elementosMenu.SubSubMenuListarPerfiles);
        }
        /// <summary>
        /// Método que presiona el boton VerDetalle de acuerdo a lo mostrado en excel, 
        /// si no se encuentra ningun registro este tomara el primero de la tabla
        /// a modo de probar la funcionalidad. 
        /// </summary>
        /// <param name="DescripcionPerfil"></param>
        public void VerDetallePerfil(string DescripcionPerfil, string GrupoPerfil)
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
                                tds[i + 2].FindElement(By.Id("btnDetalle")).Click();
                                flag = false;
                                return;
                            }

                        }

                    }
                    if (btnSiguiente.GetAttribute("class") == "paginate_button page-item next disabled")
                    {
                        WaitAndClickElement(btnVerDetalle);
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
                throw new ExcepcionPrueba("Error al Visualizar el Detalle de un Perfil");
            }
        }

        public void verificarCantidadElementos()
        {
            var detalleRegistro = PropiedadDriver.GetDriver.FindElement(By.Id("cuerpo-modal-detalle"));
            foreach (var elementos in detalleRegistro.FindElements(By.TagName("dl")))
            {
                var ele = elementos.FindElements(By.TagName("dd"));
                if (ele.Count() != 3)
                {
                    throw new ExcepcionPrueba("Cantidad de elementos de pantala incorrecta");
                }
            }
        }

        public void VerificarElementos(string DescripcionPerfil, string GrupoPerfil)
        {
            System.Threading.Thread.Sleep(3000);

            var detalleRegistro = PropiedadDriver.GetDriver.FindElement(By.Id("cuerpo-modal-detalle"));
            foreach (var elementos in detalleRegistro.FindElements(By.TagName("dl")))
            {
                var ele = elementos.FindElements(By.TagName("dd"));
                try
                {
                    //bool desReadOnly = bool.Parse(PropiedadDriver.GetDriver.FindElement(By.Id("Descripcion")).GetAttribute("readonly type"));
                    //bool gruReadOnly = bool.Parse(PropiedadDriver.GetDriver.FindElement(By.Id("GrupoDescripcion")).GetAttribute("readonly type"));

                    var textoDescripcion = PropiedadDriver.GetDriver.FindElement(By.Id("Descripcion")).GetAttribute("value readonly type").Trim();
                    var textoGrupo = PropiedadDriver.GetDriver.FindElement(By.Id("GrupoDescripcion")).GetAttribute("value").Trim();

                    if (textoDescripcion == DescripcionPerfil.Trim() && textoGrupo == GrupoPerfil.Trim())
                    {
                        WaitAndClickElement(btnCerrar);
                    }
                    else
                    {
                        throw new ExcepcionPrueba("Lasdjhdksahdkjasd");
                    }

                }
                catch (ExcepcionPrueba)
                {

                    throw new ExcepcionPrueba("Se espera que los elementos mostrados sean solamente Descripción y Grupo");
                }
            }
        }

        public void CerrarVentana()
        {

            WaitAndClickElement(btnCerrar);

        }


    }
}
