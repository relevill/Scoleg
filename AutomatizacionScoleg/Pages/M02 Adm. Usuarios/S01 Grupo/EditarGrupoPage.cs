using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S01_Grupo
{
    /// <summary>
    /// Elementos Web del Login.
    /// </summary>
    public class EditarGrupoPage : BasePage
    {
        //Constructor de la clase
        public EditarGrupoPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.ClassName, Using = "select2-selection__rendered")]
        public IWebElement ddlModulos;

        [FindsBy(How = How.Id, Using = "btn-editar")]
        public IWebElement btnEditar;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmarEdicion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;
        #endregion

        /// Pulsar botón Editar para un registro de la grilla
        /// </summary>
        public void PulsarBotonEditarGrupo(string DescripcionSearch)
        {
            ClickElementGrid(DescripcionSearch, "example", 1, "btnEditar");
        }

        /// <summary>
        /// Verificar la carga de la página para editar grupo usuario
        /// </summary>
        public bool ValidarPáginaEditarGrupo()
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
        public void EditarGrupo(string DescripcionEdit, string ModulosEdit)
        {
            ClearAndSendKeys(txtDescripcion, DescripcionEdit);
            WaitAndClickElement(ddlModulos);
            SelectOptionDropDown("li[class*='select2-results__option'", ModulosEdit);
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
        public void ValidarEdicionRegistroGrupoUsuarios(string DescripcionEdit)
        {
            FindValueInGrid(DescripcionEdit, "example");
        }
    }
}
