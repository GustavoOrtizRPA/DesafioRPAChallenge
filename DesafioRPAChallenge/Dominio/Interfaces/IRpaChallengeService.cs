
namespace Dominio.Interfaces
{
    public interface IRpaChallengeService
    {
        /// <summary>
        /// Instanciar o navegador
        /// </summary>
        void AbrirSite();

        /// <summary>
        /// Navegar para uma url
        /// </summary>
        void GoToUrl();
    }
}
