using Dominio.Interfaces;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Infraestrutura.Services.OutlookService
{
    public class OutlookService : IOutlookService
    {
        public void EnviarEmail(string filePath, string resultado)
        {
            // Criar uma instância do aplicativo Outlook
            Outlook.Application outlookApp = new Outlook.Application();

            // Criar um novo item de e-mail
            Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            // Preencher os detalhes do e-mail
            mailItem.Subject = "Desafio RPA";
            mailItem.Body = $"Boa tarde, Segue resultado do desafio: {resultado}";
            mailItem.To = "leeticiaferro@outlook.com"; // Endereço de e-mail do destinatário

            // Anexar um arquivo (opcional)
            mailItem.Attachments.Add(filePath);

            // Enviar o e-mail
            mailItem.Send();

            // Liberar recursos
            System.Runtime.InteropServices.Marshal.ReleaseComObject(mailItem);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookApp);
        }
    }
}
