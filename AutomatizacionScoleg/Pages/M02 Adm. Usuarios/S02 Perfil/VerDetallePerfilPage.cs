using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S02_Perfil
{
    public class VerDetallePerfilPage : BasePage
    {
        //Constructor de la clase
        public VerDetallePerfilPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.Id, Using = "GrupoDescripcion")]
        public IWebElement txtGrupo;

        [FindsBy(How = How.Id, Using = "modal-detalle")]
        public IWebElement modDetallePerfil;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-detalle")]
        public IWebElement btnCerrarDetalle;
        #endregion

        /// <summary>
        /// Pulsar botón Detalle para un registro de la grilla
        /// </summary>
        public void VerDetallePerfil(string DescripcionSearch)
        {
            ClickElementGrid(DescripcionSearch, "example", 1, "btnDetalle");
        }

        /// <summary>
        /// Validar despliegue modal detalle de grupo
        /// </summary>
        public bool ValidarDespliegueModalDetallePerfil()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(modDetallePerfil);
        }

        /// <summary>
        /// Validar la cantidad de campos desplegados en el modal y que se encuentren en modo solo léctura.
        /// </summary>
        public void ValidarCamposDetallePerfil()
        {
            System.Threading.Thread.Sleep(1000);
            CheckQtyElements("cuerpo-modal-detalle", 2);
            IsElementReadOnly(txtDescripcion);
        }

        /// <summary>
        /// Validar la información desplegada para los campos del detalle del perfil
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
        public void CerrarModalDetallePerfil()
        {
            ClickElement(btnCerrarDetalle);
        }

    }
}
