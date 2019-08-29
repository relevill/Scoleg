using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using System;
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

        [FindsBy(How = How.LinkText, Using = "Listar Grupos Usuarios")]
        public IWebElement SubSubMenuListarGrupoUsuarios;

        [FindsBy(How = How.LinkText, Using = "Perfiles")]
        public IWebElement SubMenuPerfiles;

        [FindsBy(How = How.LinkText, Using = "Ingresar Perfil")]
        public IWebElement SubSubMenuIngresarPerfil; 

        [FindsBy(How = How.LinkText, Using = "Listar Perfiles")]
        public IWebElement SubSubMenuListarPerfiles;

        [FindsBy(How = How.LinkText, Using = "Ingresar Grupo Usuarios")]
        public IWebElement SubSubMenuIngresarGrupoUsuarios;


        #endregion

        #region Métodos de la clase
        public static void PosicionarCursor(IWebElement elemento)
        {
            Actions actions = new Actions(PropiedadDriver.GetDriver);
            actions.MoveToElement(elemento).Build().Perform();
        }
        #endregion
    }
}