using OpenQA.Selenium;

namespace AutomatizacionScoleg.Utilidades.Pages
{
    public interface IBasePage
    {
        /// <summary>
        /// Limpiar e introducir valores en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        /// <param name="keys">Valores</param>
        void ClearAndSendKeys(IWebElement element, string keys);

        /// <summary>
        /// Introducir valores en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        /// <param name="keys">Valores</param>
        void SendKeys(IWebElement element, string keys);

        /// <summary>
        /// Obtener el valor del elemento
        /// </summary>
        /// <returns>Valor del elemento</returns>
        /// <param name="element">Element.</param>
        string GetValueElement(IWebElement element);

        /// <summary>
        /// Verificar si elemento es mostrado
        /// </summary>
        /// <returns><c>true</c>, si el elemento es mostrado, <c>false</c> lo contrario</returns>
        /// <param name="element">Element.</param>
        bool IsElementDisplayed(IWebElement element);

        /// <summary>
        /// Realizar clic en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        void ClickElement(IWebElement element);

        /// <summary>
        /// Esperar y realizar clic en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        void WaitAndClickElement(IWebElement element);

        /// <summary>
        /// Obtener título de la página
        /// </summary>
        string GetTitleUrl();
    }
}
