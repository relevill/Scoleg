﻿using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using AutomatizacionScoleg.Utilidades.Steps;

namespace AutomatizacionScoleg.Pages._02._Administrador._01._Administrador_de_Usuarios
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

        [FindsBy(How = How.Id, Using = "btn-registrar")]
        public IWebElement btnRegistrar;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnConfirmarCreacion;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrarConfirmacion;

        [FindsBy(How = How.Id, Using = "example_filter")]
        public IWebElement txtBuscar;

        #endregion

        /// <summary>
        /// Seleccionar opción de menú ingresar grupo usuarios
        /// </summary>
        public void IngresarMenuIngresarGrupoUsuarios()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MenuPage.PosicionarCursor(elementosMenu.SubMenuGrupoUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuIngresarGrupoUsuarios);
        }

        /// <summary>
        /// Verificar la carga de la página para ingreso de grupo usuario
        /// </summary>
        /// <returns><c>true</c> página cargada <c>false</c> página no cargada </returns>
        public bool ValidarPáginaIngresarGrupo()
        {
            System.Threading.Thread.Sleep(1000);
            return IsElementDisplayed(txtDescripcion);
        }

        /// <summary>
        /// Completar información ingreso de grupo usuario
        /// </summary>
        public void CompletarIngresoGrupo(string Descripción)
        {
            ClearAndSendKeys(txtDescripcion, Descripción);
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
        /// Verificar despliegue página principal
        /// </summary>
        /// <returns><c>true</c> página cargada <c>false</c> página no cargada </returns>
        public bool ValidarCreacionRegistroGrupoUsuarios()
        {
            return IsElementDisplayed(txtBuscar);

        }

    }
}
