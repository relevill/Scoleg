using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomatizacionScoleg.Utilidades.Pages
{
    /// <summary>
    /// Elementos Web del Login.
    /// </summary>
    public class MenuPage : BasePage
    {
        //Constructor de la clase
        public MenuPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web
        [FindsBy(How = How.LinkText, Using = "Mantenedores")]
        public IWebElement MenuMantenedores;

        [FindsBy(How = How.LinkText, Using = "Grupo Usuarios")]
        public IWebElement SubMenuGrupoUsuarios;

        [FindsBy(How = How.LinkText, Using = "Ingresar Grupo Usuarios")]
        public IWebElement SubSubMenuIngresarGrupoUsuarios;

        [FindsBy(How = How.LinkText, Using = "Listar Grupos Usuarios")]
        public IWebElement SubSubMenuListarGruposUsuarios;

        [FindsBy(How = How.LinkText, Using = "Perfiles")]
        public IWebElement SubMenuPerfilUsuarios;

        [FindsBy(How = How.LinkText, Using = "Ingresar Perfil")]
        public IWebElement SubSubMenuIngresarPerfilUsuarios;
        
        [FindsBy(How = How.LinkText, Using = "Listar Perfiles")]
        public IWebElement SubSubMenuListarPerfilUsuarios;

        [FindsBy(How = How.LinkText, Using = "Usuarios")]
        public IWebElement SubMenuUsuarios;

        [FindsBy(How = How.LinkText, Using = "Ingresar Usuarios")]
        public IWebElement SubSubMenuIngresarUsuarios;

        [FindsBy(How = How.LinkText, Using = "Listar Usuarios")]
        public IWebElement SubSubMenuListarUsuarios;
        #endregion
    }
}