using System;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


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
        #endregion
    }
}
