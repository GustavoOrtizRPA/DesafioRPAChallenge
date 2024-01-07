using Dominio.Interfaces;

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

        public void GoToUrl()
        {
            _webDriverService.GoToUrl("https://rpachallenge.com/");
        }
    }
}