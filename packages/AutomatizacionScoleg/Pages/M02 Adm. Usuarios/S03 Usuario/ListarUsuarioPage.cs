using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;


namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S03_Usuario
{
    public class ListarUsuarioPage : BasePage
    {
        public ListarUsuarioPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Consultas a base de datos
        string consultaListarUsuarios = "Select * from LS_USR;";
        #endregion

        /// <summary>
        /// Seleccionar opción de menú listar usuarios
        /// </summary>
        public void IngresarMenuListarUsuarios()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MoveToElement(elementosMenu.SubMenuUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuListarUsuarios);
        }

        /// <summary>
        /// Validar que la cantidad de registros desplegada en el sistema concuerde
        /// con la cantidad de registros ecistentes en base de datos
        /// </summary>
        public void ValidarCantidadRegistrosGrilla()
        {
            var filasBD = CountRegistersBD(consultaListarUsuarios);
            var filas = CountGridRows("//*[@id='example']/tbody/tr");

            if (filasBD == filas)
            {
                return;
            }
            else
            {
                throw new Exception("El sistema no despliega la cantidad de registros existentes en base de datos. Cantidad registros en sistema: " + filas + ", cantidad de registros en base de datos: " + filasBD);
            }

        }
    }
}
