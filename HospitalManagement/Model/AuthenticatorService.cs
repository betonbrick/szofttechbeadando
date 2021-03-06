using System.Linq;

namespace HospitalManagement.Model
{
    public class AuthenticatorService
    {
        private HospitalEntities loginEntities;

        public AuthenticatorService()
        {
            loginEntities = new HospitalEntities();
        }

        public bool Authenticate(string username, string password)
        {
            bool isAuthenticated = false;
            if (checkCredentials(username, password))
            {
                var query = loginEntities.Admins.Where(login => login.Username == username && login.Password == password).FirstOrDefault();

                if (query != null)
                {
                    return isAuthenticated = true;
                }
                else
                {
                    return isAuthenticated = false;
                }

            }

            return isAuthenticated;
        }

        public bool checkCredentials(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }
            else if (username.Equals("") || password.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
