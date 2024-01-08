using Dominio.Interfaces;
using OfficeOpenXml;

namespace Executor
{
    public class Runner : IRunner
    {
        private readonly IRpaChallengeService _rpaChallengeService;
        private readonly IWindowsService _windowsService;
        private readonly IOutlookService _outlookService;
        private readonly string _diretorioBase = @"C:\Users\Gustt\Downloads";

        public Runner(
            IRpaChallengeService rpaChallengeService,
            IWindowsService windowsService,
            IOutlookService outlookService

            ) 
        {
            _rpaChallengeService = rpaChallengeService;
            _windowsService = windowsService;
            _outlookService = outlookService;
        }

        public void Run()
        {
            try
            {
                _windowsService.Taskkill();
                _rpaChallengeService.AbrirSite();
                _rpaChallengeService.GoToUrl();
                _rpaChallengeService.DownloadExcel();
                _rpaChallengeService.ClicarStart();

                // Procura por arquivos .xlsx no diretório base e suas subpastas
                string[] arquivosXlsx = Directory.GetFiles(_diretorioBase, "*.xlsx", SearchOption.AllDirectories);

                if (arquivosXlsx.Length <= 0)
                {
                    Console.WriteLine("Nenhum arquivo .xlsx encontrado no diretório base e suas subpastas.");
                    return;
                }

                foreach (string arquivoXlsx in arquivosXlsx)
                {
                    Console.WriteLine(arquivoXlsx);
                    break;
                }

                Console.WriteLine(arquivosXlsx[0]);

                // Abre o arquivo Excel
                using (var package = new ExcelPackage(new FileInfo(arquivosXlsx[0])))
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    // Acessa a planilha desejada (por índice, começando em 0)
                    var worksheet = package.Workbook.Worksheets[0];

                    // Obtém as dimensões da planilha (número de linhas e colunas)
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    // Loop para percorrer os dados
                    for (int row = 1; row <= rowCount; row++)
                    {
                        var status = string.Empty;
                        var mensagem = string.Empty;

                        // Obtém o valor da célula na linha atual e coluna atual
                        var firstName = (string)worksheet.Cells[row, 1].Value;
                        var lastName = (string)worksheet.Cells[row, 2].Value;
                        var companyName = (string)worksheet.Cells[row, 3].Value;
                        var roleCompany = (string)worksheet.Cells[row, 4].Value;
                        var address = (string)worksheet.Cells[row, 5].Value;
                        var email = (string)worksheet.Cells[row, 6].Value;
                        var phoneNumber = worksheet.Cells[row, 7].Value;
                        try
                        {
                            if (firstName == null)
                            {
                                break;
                            }

                            if (firstName.Equals("First Name"))
                            {
                                continue;
                            }

                            Console.WriteLine($"First name: {firstName}");
                            Console.WriteLine($"Last name: {lastName}");
                            Console.WriteLine($"Company name: {companyName}");
                            Console.WriteLine($"Role company: {roleCompany}");
                            Console.WriteLine($"Address: {address}");
                            Console.WriteLine($"Email: {email}");
                            Console.WriteLine($"Phone number: {phoneNumber}");

                            _rpaChallengeService.PreencherFormulario(firstName.ToString(), lastName.ToString(), companyName.ToString(), roleCompany.ToString(), address.ToString(), email.ToString(), phoneNumber.ToString());
                            _rpaChallengeService.ClicarSubmit();
                            status = "Sucesso";
                            mensagem = string.Empty;
                        }
                        catch (Exception e)
                        {
                            status = "Falha";
                            mensagem = e.Message;
                        }

                    }
                }

                var resultadoDesafio = _rpaChallengeService.ResultadoDesafio();

                _outlookService.EnviarEmail(arquivosXlsx[0], resultadoDesafio);
                
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
