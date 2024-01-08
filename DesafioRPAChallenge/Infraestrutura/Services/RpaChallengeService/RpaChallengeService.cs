using Dominio.Interfaces;
using OpenQA.Selenium;

namespace Infraestrutura.Services.RpaChallengeService
{
    public class RpaChallengeService : IRpaChallengeService
    {
        private readonly IWebDriverService _webDriverService;

        public RpaChallengeService(IWebDriverService webDriverService) 
        {
            _webDriverService = webDriverService;
        }

        public void AbrirSite()
        {
            _webDriverService.InicializarNavegador();
        }

        public void ClicarStart()
        {
            var by = By.XPath("/html/body/app-root/div[2]/app-rpa1/div/div[1]/div[6]/button");
            var botaoStart = _webDriverService.TryGetElement(by, 10);
            botaoStart.Click();
        }

        public void ClicarSubmit()
        {
            var by = By.CssSelector("input[value='Submit']");
            var botaoSubmit = _webDriverService.TryGetElement(by, 10);
            botaoSubmit.Click();
        }

        public void DownloadExcel()
        {
            var by = By.XPath("/html/body/app-root/div[2]/app-rpa1/div/div[1]/div[6]/a");
            var botaoDownloadExcel = _webDriverService.TryGetElement(by, 10);
            botaoDownloadExcel.Click();
        }

        public void GoToUrl()
        {
            _webDriverService.GoToUrl("https://rpachallenge.com/");
        }

        public void PreencherFormulario(string firstName, string lastName, string companyName, string roleCompany, string address, string email, string phoneNumber)
        {
            var by = By.CssSelector("input[ng-reflect-name='labelFirstName']");
            var inputFirstName = _webDriverService.TryGetElement(by, 10);
            inputFirstName.SendKeys(firstName);

            by = By.CssSelector("input[ng-reflect-name='labelLastName'");
            var inputLastName = _webDriverService.TryGetElement(by, 10);
            inputLastName.SendKeys(lastName);

            by = By.CssSelector("input[ng-reflect-name='labelCompanyName'");
            var inputCompanyName = _webDriverService.TryGetElement(by, 10);
            inputCompanyName.SendKeys(companyName);

            by = By.CssSelector("input[ng-reflect-name='labelRole'");
            var inputRoleCompany = _webDriverService.TryGetElement(by, 10);
            inputRoleCompany.SendKeys(roleCompany);

            by = By.CssSelector("input[ng-reflect-name='labelAddress'");
            var inputAddress = _webDriverService.TryGetElement(by, 10);
            inputAddress.SendKeys(address);

            by = By.CssSelector("input[ng-reflect-name='labelEmail'");
            var inputEmail = _webDriverService.TryGetElement(by, 10);
            inputEmail.SendKeys(email);

            by = By.CssSelector("input[ng-reflect-name='labelPhone'");
            var inputPhone = _webDriverService.TryGetElement(by, 10);
            inputPhone.SendKeys(phoneNumber);
        }

        public string ResultadoDesafio()
        {
            var by = By.XPath("/html/body/app-root/div[2]/app-rpa1/div/div[2]/div[1]");
            var labelCongratulation = _webDriverService.TryGetElement(by, 10);
            return labelCongratulation.Text;

        }
    }
}