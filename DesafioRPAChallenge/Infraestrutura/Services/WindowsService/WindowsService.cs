
using Dominio.Interfaces;
using System.Diagnostics;

namespace Infraestrutura.Services.WindowsService
{
    public class WindowsService : IWindowsService
    {
        /// <summary>
        /// Matar processos utilizados
        /// </summary>
        public void Taskkill()
        {
            var processlist = Process.GetProcesses().Where(p => p.ProcessName.ToLower().Contains("chrome"));
            foreach (var process in processlist)
            {
                process.Kill();
            }
        }
    }
}
