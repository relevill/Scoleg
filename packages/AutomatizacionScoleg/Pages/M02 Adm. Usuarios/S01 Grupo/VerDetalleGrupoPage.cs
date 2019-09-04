using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S01_Grupo
{
    /// <summary>
    /// Elementos Web del Login.
    /// </summary>
    public class VerDetalleGrupoPage : BasePage
    {
        //Constructor de la clase
        public VerDetalleGrupoPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.Id, Using = "Modulos")]
        public IWebElement txtModulos;

        [FindsBy(How = How.Id, Using = "modal-detalle")]
        public IWebElement modDetalleGrupo;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-detalle")]
        public IWebElement btnCerrarDetalle;
        #endregion

        /// <summary>
        /// Pulsar botón Detalle para un registro de la grilla
        /// </summary>
        public void VerDetalleGrupo(string DescripcionSearch)
        {
            ClickElementGrid(DescripcionSearch, "example", 1, "btnDetalle");
        }

        /// <summary>
        /// Validar despliegue modal detalle de grupo
        /// </summary>
        public bool ValidarDespliegueModalDetalleGrupo()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(modDetalleGrupo);
        }

        /// <summary>
        /// Validar la cantidad de campos desplegados en el modal y que se encuentren en modo solo léctura.
        /// </summary>
        public void ValidarCamposDetalleGrupo()
        {
            System.Threading.Thread.Sleep(1000);
            CheckQtyElements("cuerpo-modal-detalle", 2);
            IsElementReadOnly(txtDescripcion);
        }

        /// <summary>
        /// Validar la información desplegada para los campos del detalle del grupo
        /// </summary>
        public void ValidarInformacionDesplegada(string Descripcion)
        {
            System.Threading.Thread.Sleep(3000);
            var textoDescripcion = txtDescripcion.GetAttribute("value").Trim();

            if (!(textoDescripcion.Equals(Descripcion.Trim())))
            {
                throw new ExcepcionPrueba("La información desplegada en el detalle no concuerda con la esperada");
            }

        }

        /// <summary>
        /// Cerrar el modal de detalle grupo usuario
        /// </summary>
        public void CerrarModalDetalleGrupoUsuario()
        {
            ClickElement(btnCerrarDetalle);
        }

    }
}
