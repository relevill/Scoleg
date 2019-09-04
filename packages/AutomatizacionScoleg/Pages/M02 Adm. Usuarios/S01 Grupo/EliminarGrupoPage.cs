using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S01_Grupo
{
    public class EliminarGrupoPage:BasePage
    {
        //Constructor de la clase
        public EliminarGrupoPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "btn-eliminar")]
        public IWebElement btnEliminar;

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.ClassName, Using = "select2-selection__rendered")]
        public IWebElement ddlModulos;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmarEliminacion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;
        #endregion

        /// Pulsar botón Eliminar para un registro de la grilla
        /// </summary>
        public void PulsarBotonEliminarGrupo(string DescripcionSearch)
        {
            ClickElementGrid(DescripcionSearch, "example", 1, "btnEliminar");
        }

        /// <summary>
        /// Validar despliegue formulario detalle de grupo
        /// </summary>
        public bool ValidarDespliegueEliminarGrupo()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        /// <summary>
        /// Validar la cantidad de campos desplegados en el modal y que se encuentren en modo solo léctura.
        /// </summary>
        public void ValidarCamposDetalleGrupo()
        {
            System.Threading.Thread.Sleep(1000);
            CheckQtyElements("formulario", 2);
            IsElementReadOnly(txtDescripcion);
            PropiedadDriver.GetDriver.FindElement(By.Id("ModulosSeleccionados")).GetAttribute("disabled").Equals("true");
        }

        /// <summary>
        /// Validar la información desplegada para los campos al eliminar grupo
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
        /// Pulsar botón eliminar
        /// </summary>
        public void PulsarBotonEliminar()
        {
            WaitAndClickElement(btnEliminar);
        }

        /// <summary>
        /// Pulsar botón confirmar creación
        /// </summary>
        public void PulsarConfirmarEliminacion()
        {
            WaitAndClickElement(btnConfirmarEliminacion);
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
        public void ValidarEliminacionRegistroGrupoUsuarios(string DescripcionSearch)
        {
            CheckErasedValueInGrid(DescripcionSearch, "example");

        }
    }
}
