using AutomatizacionScoleg.Utilidades;
using AutomatizacionScoleg.Utilidades.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionScoleg.Pages.M02_Adm._Usuarios.S2_Perfil
{
    public class ListarPerfilPage : BasePage
    {
        public ListarPerfilPage()
        {
            PageFactory.InitElements(PropiedadDriver.GetDriver, this);
        }

        #region Elementos Web

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion;

        [FindsBy(How = How.Id, Using = "example_next")]
        public IWebElement btnSiguiente;

        [FindsBy(How = How.Id, Using = "select2-GrupoCodigo-container")]
        public IWebElement ddlGrupo;

        [FindsBy(How = How.Id, Using = "btn-registrar")]
        public IWebElement btnRegistrar;

        [FindsBy(How = How.Id, Using = "btn-aceptar-modal-confirmar")]
        public IWebElement btnAceptar;

        [FindsBy(How = How.Id, Using = "btn-cerrar-modal-mensaje")]
        public IWebElement btnCerrar;

        #endregion

        /// <summary>
        /// Seleccionar opción de menú ingresar grupo usuarios
        /// </summary>
        public void IngresarMenuListarPerfil()
        {
            MenuPage elementosMenu = new MenuPage();
            WaitAndClickElement(elementosMenu.MenuMantenedores);
            MenuPage.PosicionarCursor(elementosMenu.SubMenuPerfiles);
            WaitAndClickElement(elementosMenu.SubSubMenuListarPerfiles);
        }

        public void verificarCantidadElementos()
        {
            var countElementos = PropiedadDriver.GetDriver.FindElement(By.XPath("//*[@id='main - content']/article/div[1]/div"));
            foreach (var elementos in countElementos.FindElements(By.TagName("div p")))
            {
                var ele = elementos.FindElements(By.TagName("dd"));
                if (ele.Count() != 3)
                {
                    throw new ExcepcionPrueba("Cantidad de elementos de pantala incorrecta");
                }
            }
        }

        public int ContarFilas()
        {
            //var countElementos = PropiedadDriver.GetDriver.FindElements(By.XPath("//*[@id='main - content']/article/div[1]/div"));
            int count = 0;
            while (btnSiguiente.GetAttribute("class") == "paginate_button page-item next")
            {
                var filas = PropiedadDriver.GetDriver.FindElements(By.XPath("//*[@id='example']/tbody/tr")).Count();
                count = count + filas;
                btnSiguiente.Click();
            }

            if (btnSiguiente.GetAttribute("class") == "paginate_button page-item next disabled")
            {
                var filas = PropiedadDriver.GetDriver.FindElements(By.XPath("//*[@id='example']/tbody/tr")).Count();
                count = count + filas;
            }
            
            return count;
        }

        public int GetQueryResult(String vConnectionString, String vQuery)
        {
            SqlConnection Connection; 
            DataSet ds = new DataSet();  

            try
            {
                Connection = new SqlConnection(vConnectionString);  // Declarar conexión SQL con la cadena de conexión 
                Connection.Open();  // Conéctese a la base de datos

                SqlDataAdapter adp = new SqlDataAdapter(vQuery, Connection);  // Execute query on database 

                adp.Fill(ds);   // Almacenar el resultado de la consulta en el objeto DataSet    

                Connection.Close();  // Cierra la connection 
                Connection.Dispose();   // Elimina la connection             
            }
            catch (Exception E)
            {
                Console.WriteLine("Error al obtener el resultado de la consulta.");
                Console.WriteLine(E.Message);
                return -1;
                //return new DataTable();
            }


            return ds.Tables[0].Rows.Count;
        }

    }
}
