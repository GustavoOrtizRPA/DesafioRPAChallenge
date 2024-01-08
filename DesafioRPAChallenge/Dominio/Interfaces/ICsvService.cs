

namespace Dominio.Interfaces
{
    public interface ICsvService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="companyName"></param>
        /// <param name="roleCompany"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="status"></param>
        /// <param name="mensagem"></param>
        public void Write(
            string path,
            string firstName, 
            string lastName, 
            string companyName, 
            string roleCompany, 
            string address, 
            string email, 
            string phoneNumber,
            string status,
            string mensagem);
    }
}
