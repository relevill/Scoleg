using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios
{
    class EditarGrupoPage : BasePage
    {
        public EditarGrupoPage()
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

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnAceptar;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarMesajeError;
        #endregion
        public void PosicionarListar()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MenuPage.PosicionarCursor(elementosMenu.SubMenuGrupoUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuListarGrupoUsuarios);
        }
        public void IngresarEditarGrupoUsuarios(string Descripcion)
        {
            IList<IWebElement> grupos = PropiedadDriver.GetDriver.FindElements(By.ClassName("table table-striped table-bordered dataTable no-footer"));
            try
            {
                foreach (IWebElement element in grupos)
                {
                    if (element.Text.Equals(Descripcion))
                    {
                        WaitAndClickElement(btnEditarListar);
                        break;
                    }


                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("Error al Seleccionar un Grupo para ingresar Perfil");
            }


        }
        public bool ValidarPáginaEditarGrupo()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        public void CompletarDescripcionEditar(string DescripcionModificar)
        {
            ClearAndSendKeys(txtDescripcion, DescripcionModificar);
        }

        public void PulsarBotonEditar()
        {
            WaitAndClickElement(btnEditar);
        }

        public void PulsarBotonConfirmar()
        {
            WaitAndClickElement(btnAceptar);
        }

        //Caso de uso con defecto vigente, al momento de cerrarlo modificar id boton.
        public void PulsarBotonCerrar()
        {
            WaitAndClickElement(btnCerrarMesajeError);
        }
    }
}
