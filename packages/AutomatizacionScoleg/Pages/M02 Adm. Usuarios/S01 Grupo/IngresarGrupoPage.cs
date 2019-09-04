using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S01_Grupo
{/// <summary>
 /// Elementos Web del Login.
 /// </summary>
    public class IngresarGrupoPage : BasePage
    {
        //Constructor de la clase
        public IngresarGrupoPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.ClassName, Using = "select2-selection__rendered")]
        public IWebElement ddlModulos;

        [FindsBy(How = How.Id, Using = "btn-registrar")]
        public IWebElement btnRegistrar;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmarCreacion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;
        #endregion

        /// <summary>
        /// Seleccionar opción de menú ingresar grupo usuarios
        /// </summary>
        public void IngresarMenuIngresarGrupoUsuarios()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MoveToElement(elementosMenu.SubMenuGrupoUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuIngresarGrupoUsuarios);
        }

        /// <summary>
        /// Verificar la carga de la página para ingreso de grupo usuario
        /// </summary>
        public bool ValidarPáginaIngresarGrupo()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        /// <summary>
        /// Completar información ingreso de grupo usuario
        /// </summary>
        public void CompletarIngresoGrupo(string Descripcion, string Modulos)
        {
            ClearAndSendKeys(txtDescripcion, Descripcion);
            WaitAndClickElement(ddlModulos);
            SelectOptionDropDown("li[class*='select2-results__option'", Modulos);
        }

        /// <summary>
        /// Pulsar botón Registrar
        /// </summary>
        public void PulsarBotonRegistrar()
        {
            WaitAndClickElement(btnRegistrar);
        }

        /// <summary>
        /// Pulsar botón confirmar creación
        /// </summary>
        public void PulsarConfirmarCreacion()
        {
            WaitAndClickElement(btnConfirmarCreacion);
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
        public void ValidarCreacionRegistroGrupoUsuarios(string Descripcion)
        {
            FindValueInGrid(Descripcion, "example");
        }

    }
}

