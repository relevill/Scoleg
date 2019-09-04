using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using System.Data.SqlClient;
using System.Data;


namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S02_Perfil
{
    public class ListarPerfilPage : BasePage
    {
        //Constructor de la clase
        public ListarPerfilPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Consultas a base de datos
        string consultaListarPerfiles = "select * from LS_GRP_PERF;";
        #endregion

        public void IngresarMenuListarPerfilUsuarios()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MoveToElement(elementosMenu.SubMenuPerfilUsuarios);
            WaitAndClickElement(elementosMenu.SubSubMenuListarPerfilUsuarios);
        }
        
        public void ValidarCantidadRegistrosGrilla()
        {
            var filasBD = CountRegistersBD(consultaListarPerfiles);
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
