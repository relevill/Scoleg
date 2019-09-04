using System;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace AutomatizacionScoleg.Utilidades.Pages
{
    public class BasePage : IBasePage
    {
        //Tiempo de espera de los elementos
        enum TimeOut
        {
            min = 10,
            medium = 30,
            max = 60
        }

        #region Métodos de la clase
        /// <summary>
        /// Limpiar e introducir valores en elemento
        /// </summary>
        public void ClearAndSendKeys(IWebElement element, string keys)
        {
            try
            {
                element.Clear();
                element.SendKeys(keys);
            }
            catch (Exception)
            {
                throw new Exception("Error al limpiar e introducir valores en el elemento");
            }
        }

        /// <summary>
        /// Introducir valores en elemento
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="keys">Keys.</param>
        public void SendKeys(IWebElement element, string keys)
        {
            try
            {
                element.SendKeys(keys);
            }
            catch
            {
                throw new Exception("Error al introducir valores en elemento");
            }
        }

        /// <summary>
        /// Obtener el valor del elemento
        /// </summary>
        /// <returns>Valor del elemento</returns>
        /// <param name="element">Element</param>
        public string GetValueElement(IWebElement element)
        {
            try
            {
                return element.GetAttribute("valor");
            }
            catch (Exception)
            {
                throw new Exception("El valor del elemento no ha sido retornado");
            }
        }

        /// <summary>
        /// Verificar si elemento es mostrado
        /// </summary>
        /// <returns><c>true</c>, si el elemento es mostrado, <c>false</c> lo contrario</returns>
        /// <param name="element">Element.</param>
        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                throw new Exception("El elemento no es mostrado");
            }
        }

        /// <summary>
        /// Realizar clic en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        public void ClickElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception)
            {
                throw new Exception("No es posible realizar clic en elemento");
            }
        }

        /// <summary>
        /// Esperar y realizar clic en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        public void WaitAndClickElement(IWebElement element)
        {
            try
            {
                PropiedadDriver.GetDriverWait((int)TimeOut.medium).Until(ExpectedConditions.ElementToBeClickable(element));

                element.Click();
            }
            catch (Exception)
            {
                throw new Exception("Se ha excedido tiempo de espera y no es posible realizar clic en elemento");
            }
        }

        /// <summary>
        /// Obtener título de la página
        /// </summary>
        /// <returns>Título de la página</returns>
        public string GetTitleUrl()
        {
            try
            {
                return PropiedadDriver.GetDriver.Title;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el título de la página");
            }
        }

        /// <summary>
        /// Obtener URL de la página
        /// </summary>
        /// <returns>Título de la página</returns>
        public string GetBrowserUrl()
        {
            try
            {
                return PropiedadDriver.GetDriver.Url;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener la URL de la página");
            }
        }

        /// <summary>
        /// Posicionar cursor en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        public void MoveToElement(IWebElement element)
        {
            try
            {
                Actions actions = new Actions(PropiedadDriver.GetDriver);
                actions.MoveToElement(element).Build().Perform();
            }
            catch (Exception)
            {
                throw new Exception("Error al posicionar el cursor en elemento");
            }
        }

        /// <summary>
        /// Seleccionar valor desde campo tipo seleccionable
        /// </summary>
        /// <param name="value">Valor a seleccionar</param>
        /// <param name="cssDropDown">Elemento</param>
        public void SelectOptionDropDown(string cssDropDown, string value)
        {
            IList<IWebElement> options = PropiedadDriver.GetDriver.FindElements(By.CssSelector(cssDropDown));
            try
            {
                foreach (IWebElement element in options)
                {
                    if (element.Text.Equals(value))
                    {
                        element.Click();
                        break;
                    }
                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("Error al seleccionar un valor desde el campo");
            }

        }

        /// <summary>
        /// Validar existencia de un valor en la grilla
        /// </summary>
        /// <param name="value">Valor a buscar en grilla</param>
        /// <param name="idTable">Id Tabla</param>
        public void FindValueInGrid(string value, string idTable)
        {
            System.Threading.Thread.Sleep(2000);
            try
            {
                bool flag = true;
                var tabla = PropiedadDriver.GetDriver.FindElement(By.Id(idTable));
                while (flag == true)
                {
                    foreach (var tr in tabla.FindElements(By.TagName("tr")))
                    {
                        var tds = tr.FindElements(By.TagName("td"));
                        for (var i = 0; i < tds.Count; i++)
                        {
                            if (tds[i].Text.Trim() == value.Trim())
                            {
                                IJavaScriptExecutor js = (IJavaScriptExecutor)PropiedadDriver.GetDriver;
                                js.ExecuteScript("arguments[0].setAttribute('style', 'color:red')", tds[i]);
                                System.Threading.Thread.Sleep(2000);
                                flag = false;
                                return;
                            }
                        }
                    }

                    if (PropiedadDriver.GetDriver.FindElement(By.Id("example_next")).GetAttribute("Class") == "paginate_button page-item next disabled")
                    {
                        throw new ExcepcionPrueba("No ha sido posible encontrar el registro en la grilla ");
                    }
                    else
                    {
                        WaitAndClickElement(PropiedadDriver.GetDriver.FindElement(By.Id("example_next")));
                    }
                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("Ha ocurrido un error al realizar la búsqueda del registro en la grilla");
            }
        }

        /// <summary>
        /// Buscar registro en la grilla y pulsar un botón de acción.
        /// </summary>
        /// <param name="value">Valor a buscar en grilla</param>
        /// <param name="idTable">Id Tabla</param>
        /// <param name="indexColActions">Indice de la columna acciones</param>
        /// <param name="idAction">Id del elemento de acción</param>
        public void ClickElementGrid(string value, string idTable, int indexColActions, string idAction)
        {
            System.Threading.Thread.Sleep(3000);
            try
            {
                bool flag = true;
                var tabla = PropiedadDriver.GetDriver.FindElement(By.Id(idTable));
                while (flag == true)
                {
                    foreach (var tr in tabla.FindElements(By.TagName("tr")))
                    {
                        var tds = tr.FindElements(By.TagName("td"));
                        for (var i = 0; i < tds.Count; i++)
                        {
                            if (tds[i].Text.Trim() == value.Trim())
                            {
                                tds[i + indexColActions].FindElement(By.Id(idAction)).Click();
                                flag = false;
                                return;
                            }
                        }
                    }

                    if (PropiedadDriver.GetDriver.FindElement(By.Id("example_next")).GetAttribute("Class") == "paginate_button page-item next disabled")
                    {
                        throw new ExcepcionPrueba("No ha sido posible encontrar el registro en la grilla ");
                    }
                    else
                    {
                        WaitAndClickElement(PropiedadDriver.GetDriver.FindElement(By.Id("example_next")));
                    }
                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("Error al pulsar un botón de acción para el registro buscado en la grilla");
            }

        }

        /// <summary>
        /// Verificar la cantidad de elementos contenidos en un modal
        /// </summary>
        /// <param name="idModal">Id Modal</param>
        /// <param name="numElements">ICantidad de elementos presentes esperados</param>
        public void CheckQtyElements(string idModal, int numElements)
        {
            System.Threading.Thread.Sleep(2000);
            var detalleRegistro = PropiedadDriver.GetDriver.FindElement(By.Id(idModal));

            foreach (var elementos in detalleRegistro.FindElements(By.TagName("dl")))
            {
                var ele = elementos.FindElements(By.TagName("dd"));
                if (ele.Count() != numElements)
                {
                    throw new ExcepcionPrueba("Cantidad incorrecta de elementos presentes en pantalla");
                }
            }
        }

        /// <summary>
        /// Verificar si elemento es de solo lectura
        /// </summary>
        /// <returns><c>true</c>, si el elemento es de solo lectura, <c>false</c> lo contrario</returns>
        /// <param name="element">Element.</param>
        public bool IsElementReadOnly(IWebElement element)
        {
            try
            {
                return element.GetAttribute("readOnly").Equals("true");
            }
            catch (Exception)
            {
                throw new Exception("El elemento no es mostrado en modo solo lectura");
            }
        }

        /// <summary>
        /// Validar en la grilla la eliminación de un registro 
        /// </summary>
        /// <param name="value">Valor a buscar en grilla</param>
        /// <param name="idTable">Id Tabla</param>
        public void CheckErasedValueInGrid(string value, string idTable)
        {
            System.Threading.Thread.Sleep(2000);
            try
            {
                bool flag = true;
                var tabla = PropiedadDriver.GetDriver.FindElement(By.Id(idTable));
                while (flag == true)
                {
                    foreach (var tr in tabla.FindElements(By.TagName("tr")))
                    {
                        var tds = tr.FindElements(By.TagName("td"));
                        for (var i = 0; i < tds.Count; i++)
                        {
                            if (tds[i].Text.Trim() == value.Trim())
                            {
                                IJavaScriptExecutor js = (IJavaScriptExecutor)PropiedadDriver.GetDriver;
                                js.ExecuteScript("arguments[0].setAttribute('style', 'color:red')", tds[i]);
                                System.Threading.Thread.Sleep(2000);
                                flag = false;
                                return;
                            }
                        }
                    }

                    if (PropiedadDriver.GetDriver.FindElement(By.Id("example_next")).GetAttribute("Class") == "paginate_button page-item next disabled")
                    {
                        break;
                    }
                    else
                    {
                        WaitAndClickElement(PropiedadDriver.GetDriver.FindElement(By.Id("example_next")));
                    }
                }
            }
            catch (ExcepcionPrueba)
            {
                throw new ExcepcionPrueba("Ha ocurrido un error al realizar la búsqueda del registro eliminado en la grilla");
            }
        }

        /// <summary>
        /// Contar la cantidad de filas de una grilla
        /// </summary>
        /// <param name="xpathTable">Id Tabla</param>
        public int CountGridRows(string xpathTable)
        {
            int count = 0;
            while ((PropiedadDriver.GetDriver.FindElement(By.Id("example_next")).GetAttribute("class") == "paginate_button page-item next"))
            {
                var filas = PropiedadDriver.GetDriver.FindElements(By.XPath(xpathTable)).Count();
                count = count + filas;
                PropiedadDriver.GetDriver.FindElement(By.Id("example_next")).Click();
            }
            if ((PropiedadDriver.GetDriver.FindElement(By.Id("example_next")).GetAttribute("class") == "paginate_button page-item next disabled"))
            {
                var filas = PropiedadDriver.GetDriver.FindElements(By.XPath(xpathTable)).Count();
                count = count + filas;
            }
            return count;
        }

        /// <summary>
        /// Obtener la cantidad de registros retornados al consultar base de datos
        /// </summary>
        /// /// <param name="Query">Consulta a base de datos</param>
        public int CountRegistersBD(string Query)

        {
            string ConnectionString = ParametrosEjecucion.CadenaConexionBD;
            SqlConnection Connection;
            DataSet ds = new DataSet();

            try
            {
                Connection = new SqlConnection(ConnectionString);  // Declarar conexión SQL con la cadena de conexión 
                Connection.Open();  // Conectarse a la base de datos

                SqlDataAdapter adp = new SqlDataAdapter(Query, Connection);  // Ejecutar consulta

                adp.Fill(ds);   // Almacenar el resultado de la consulta en el objeto DataSet    

                Connection.Close();  // Cierra la conexión
                Connection.Dispose();   // Elimina la conexión          
            }
            catch (Exception E)
            {
                Console.WriteLine("Error al consultar la base de datos");
                Console.WriteLine(E.Message);
                return -1;
            }

            return ds.Tables[0].Rows.Count;
        }
        #endregion
    }
}