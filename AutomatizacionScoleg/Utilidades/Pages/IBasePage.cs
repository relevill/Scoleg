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

        /// <summary>
        /// Obtener URL de la página
        /// </summary>
        string GetBrowserUrl();

        /// <summary>
        /// Posicionar cursor en elemento
        /// </summary>
        /// <param name="element">Elemento</param>
        void MoveToElement(IWebElement element);

        /// <summary>
        /// Seleccionar valor desde campo tipo seleccionable
        /// </summary>
        /// <param name="value">Elemento</param>
        /// <param name="elementDropDown">Elemento</param>
        void SelectOptionDropDown(string elementDropDown, string value);

        /// <summary>
        /// Buscar valor en grilla
        /// </summary>
        /// <param name="value">Valor a buscar</param>
        /// <param name="idTable">Id Tabla</param>
        void FindValueInGrid(string value, string idTable);

        /// <summary>
        /// Buscar registro en la grilla y pulsar un botón de acción,
        /// si no lo encuentra considera el primer registro a modo de probar la funcionalidad
        /// </summary>
        /// <param name="Descripcion"></param>
        void ClickElementGrid(string value, string idTable, int indexColActions, string idAction);

        /// <summary>
        /// Verificar la cantidad de elementos contenidos en un modal
        /// </summary>
        /// <param name="idModal">Id Modal</param>
        /// <param name="numElements">ICantidad de elementos presentes esperados</param>
        void CheckQtyElements(string idModal, int numElements);

        /// <summary>
        /// Verificar si elemento es de solo lectura
        /// </summary>
        /// <returns><c>true</c>, si el elemento es de solo lectura, <c>false</c> lo contrario</returns>
        /// <param name="element">Element.</param>
        bool IsElementReadOnly(IWebElement element);

        /// <summary>
        /// Validar en la grilla la eliminación de un registro 
        /// </summary>
        /// <param name="value">Valor a buscar en grilla</param>
        /// <param name="idTable">Id Tabla</param>
        void CheckErasedValueInGrid(string value, string idTable);

        /// <summary>
        /// Contar la cantidad de filas de una grilla
        /// </summary>
        /// <param name="xpathTable">Id Tabla</param>
        int CountGridRows(string xpathTable);

        /// <summary>
        /// Obtener la cantidad de registros retornados al consultar base de datos
        /// </summary>
        /// /// <param name="Query">Consulta a base de datos</param>
        int CountRegistersBD(string Query);
    }
}
