using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model
{
    public class LoginService
    {
        private HospitalEntities loginEntities;
        


        public LoginService()
        {
            loginEntities = new HospitalEntities();


        }
        //public bool AuthenticateAdmin(AdminsDTO admins)
        //{
        //    //bool isAuthenticated = false;
        //    //if (admins.isCredentialsFilled()) 
        //    //{
        //    //    var admin = from admintable in loginEntities.Admins.Where(u=>u.Username == admins.Username && u.Password== admins.Password);
        //    //    if (admin != null)
        //    //    {
        //    //        return isAuthenticated = true;
        //    //    }
        //    //    return isAuthenticated = false;
        //    //}
           
        //    return isAuthenticated;
            
        //}
    }
}
