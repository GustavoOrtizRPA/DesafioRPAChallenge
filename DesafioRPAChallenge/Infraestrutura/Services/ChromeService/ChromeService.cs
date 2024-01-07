using Dominio.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Polly.Retry;
using Polly;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Infraestrutura.Services.ChromeService
{
    public class ChromeService: IWebDriverService
    {
        /// <summary>
        /// Propriedade Driver
        /// </summary>
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// Obter um elemento
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds">Tempo a ser aguardado em segundos</param>
        /// <returns>Elemento</returns>
        /// <exception cref="NoSuchElementException"></exception>
        public IWebElement GetElement(By by, int timeoutInSeconds = 10)
        {
            var element = TryGetElement(by, timeoutInSeconds);

            if (element is null)
            {
                throw new NoSuchElementException($"Não localizou elemento com by: {by}");
            }

            return element;
        }

        /// <summary>
        /// Tentar obter o elemento
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds">Tempo a ser aguardado em segundos</param>
        /// <returns></returns>
        public IWebElement? TryGetElement(By by, int timeoutInSeconds = 10)
        {
            try
            {
                RetryPolicy policy = Policy
                .Handle<NoSuchElementException>()
                .WaitAndRetry(timeoutInSeconds, retryAttempt => TimeSpan.FromSeconds(1));

                IWebElement element = policy.Execute(() =>
                {
                    IWebElement webElement = Driver.FindElement(by);

                    if (webElement is null)
                    {
                        throw new NoSuchElementException();
                    }

                    return webElement;
                });

                return element;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Navegar para a Url
        /// </summary>
        /// <param name="url">Link da url</param>
        public void GoToUrl(string url) => Driver.Navigate().GoToUrl(url);

        /// <summary>
        /// Instanciar navegador
        /// </summary>
        public void InicializarNavegador()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), "MatchingBrowser");
            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(new List<string> { "window-size=1920,1080" });
            chromeOptions.AddArguments(new List<string> { "disable-gpu" });
            chromeOptions.AddArguments(new List<string> { "disable-extensions" });
            chromeOptions.AddArguments(new List<string> { "proxy-server='direct://'" });
            chromeOptions.AddArguments(new List<string> { "proxy-bypass-list=*" });
            chromeOptions.AddArguments(new List<string> { "start-maximized" });
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            Driver = new ChromeDriver(chromeDriverService, chromeOptions);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Obter uma lista de elementos
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds">Tempo a ser aguardado em segundos</param>
        /// <returns>Lista de elementos</returns>
        /// <exception cref="NoSuchElementException"></exception>
        public IEnumerable<IWebElement> GetElements(By by, int timeoutInSeconds = 10)
        {
            RetryPolicy policy = Policy
                .Handle<NoSuchElementException>()
                .WaitAndRetry(timeoutInSeconds, retryAttempt => TimeSpan.FromSeconds(1));

            IEnumerable<IWebElement> element = policy.Execute(() =>
            {
                IEnumerable<IWebElement> webElement = Driver.FindElements(by);

                if (webElement is null)
                {
                    throw new NoSuchElementException();
                }

                return webElement;
            });

            return element;
        }
    }
}
