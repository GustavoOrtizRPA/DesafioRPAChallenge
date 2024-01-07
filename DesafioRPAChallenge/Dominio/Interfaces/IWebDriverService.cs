using OpenQA.Selenium;

namespace Dominio.Interfaces
{
    public interface IWebDriverService
    {
        /// <summary>
        /// Instanciar navegador
        /// </summary>
        void InicializarNavegador();

        /// <summary>
        /// Navegar para a Url
        /// </summary>
        /// <param name="url">Link da url</param>
        void GoToUrl(string url);

        /// <summary>
        /// Obter um elemento
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds">Tempo a ser aguardado em segundos</param>
        /// <returns>Elemento</returns>
        /// <exception cref="NoSuchElementException"></exception>
        IWebElement GetElement(By by, int timeoutInSeconds = 10);

        /// <summary>
        /// Tentar obter o elemento
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds">Tempo a ser aguardado em segundos</param>
        IWebElement? TryGetElement(By by, int timeoutInSeconds = 10);

        /// <summary>
        /// Obter uma lista de elementos
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds">Tempo a ser aguardado em segundos</param>
        /// <returns>Lista de elementos</returns>
        /// <exception cref="NoSuchElementException"></exception>
        IEnumerable<IWebElement> GetElements(By by, int timeoutInSeconds = 10);
    }
}
