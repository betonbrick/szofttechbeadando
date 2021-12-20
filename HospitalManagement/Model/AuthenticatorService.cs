using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            if(username.Equals("") || password.Equals(""))
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
