using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S02_Perfil
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
        public IWebElement btnConfirmarEdicion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;
        
        [FindsBy(How = How.Id, Using = "example_next")]
        public IWebElement btnSiguiente;
        #endregion

        /// Pulsar botón Editar para un registro de la grilla
        /// </summary>
        public void PulsarBotonEditarPerfil(string DescripcionSearch)
        {
            ClickElementGrid(DescripcionSearch, "example", 1, "btnEditar");
        }

        /// <summary>
        /// Verificar la carga de la página para editar grupo usuario
        /// </summary>
        public bool ValidarPáginaEditarPerfil()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        /// <summary>
        /// Validar la información desplegada para los campos del formulario editar grupo
        /// </summary>
        public void ValidarInformacionDesplegada(string DescripcionSearch)
        {
            System.Threading.Thread.Sleep(3000);
            var textoDescripcion = txtDescripcion.GetAttribute("value").Trim();

            if (!(textoDescripcion.Equals(DescripcionSearch.Trim())))
            {
                throw new ExcepcionPrueba("La información desplegada en el formulario no concuerda con la esperada");
            }

        }
        /// <summary>
        /// Modificar información del grupo usuario
        /// </summary>
        public void EditarPerfil(string DescripcionEdit, string GrupoEdit)
        {
            ClearAndSendKeys(txtDescripcion, DescripcionEdit);
            WaitAndClickElement(ddlGrupo);
            SelectOptionDropDown("li[class*='select2-results__option'", GrupoEdit);
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
        public void ValidarEdicionRegistroPerfil(string DescripcionEdit)
        {
            FindValueInGrid(DescripcionEdit, "example");
        }

    }
}
