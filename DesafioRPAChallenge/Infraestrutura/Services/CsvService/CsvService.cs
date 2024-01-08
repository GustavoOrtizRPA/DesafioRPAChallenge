using Dominio.Interfaces;
using System.Text;

namespace Infraestrutura.Services.CsvService
{
    public class CsvService : ICsvService
    {
        public void Write(string path,string firstName, string lastName, string companyName, string roleCompany, string address, string email, string phoneNumber)
        {
            if (Directory.Exists(Path.GetDirectoryName(path))) 
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Data;FirstName;LastName;Company Name;Role Company;Address;Phone Number\n");
            }

            File.AppendAllText(path, $"{DateTime.Now};{firstName};{lastName};{companyName};{roleCompany};{address};{email},{phoneNumber}\n", Encoding.Unicode);
        }
    }
}
