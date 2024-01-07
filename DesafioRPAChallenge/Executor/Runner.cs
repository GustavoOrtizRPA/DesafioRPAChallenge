
using Dominio.Interfaces;

namespace Executor
{
    public class Runner : IRunner
    {
        private readonly IRpaChallengeService _rpaChallengeService;
        private readonly IWindowsService _windowsService;

        public Runner(
            IRpaChallengeService rpaChallengeService,
            IWindowsService windowsService

            ) 
        {
            _rpaChallengeService = rpaChallengeService;
            _windowsService = windowsService;
        }

        public void Run()
        {
            try
            {
                _windowsService.Taskkill();
                _rpaChallengeService.AbrirSite();
                _rpaChallengeService.GoToUrl();
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
