using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S01_Grupo
{
    /// <summary>
    /// Elementos Web del Login.
    /// </summary>
    public class ListarGrupoPage : BasePage
    {
        //Constructor de la clase
        public ListarGrupoPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Consultas a base de datos
        string consultaListarGrupos = "select * from LS_GRP_PERF;";
        #endregion

        /// <summary>
        /// Seleccionar opción de menú listar grupos usuarios
        /// </summary>
        public void IngresarMenuListarGruposUsuarios()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MoveToElement(elementosMenu.SubMenuGrupoUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuListarGruposUsuarios);
        }

        /// <summary>
        /// Validar que la cantidad de registros desplegada en el sistema concuerde
        /// con la cantidad de registros ecistentes en base de datos
        /// </summary>
        public void ValidarCantidadRegistrosGrilla()
        {
            var filasBD = CountRegistersBD(consultaListarGrupos);
            var filas = CountGridRows("//*[@id='example']/tbody/tr");

            if (filasBD == filas)
            {
                return;
            }
            else
            {
                throw new Exception("El sistema no despliega la cantidad de registros existentes en base de datos. Cantidad registros en sistema: " + filas +", cantidad de registros en base de datos: " + filasBD);
            }

        }
    }
}
