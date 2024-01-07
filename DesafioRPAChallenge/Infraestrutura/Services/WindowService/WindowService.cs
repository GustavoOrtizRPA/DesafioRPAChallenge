using System.Diagnostics;

namespace Infraestrutura.Services.WindowService
{
    public class WindowService
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
