using HospitalManagement.Model;
using HospitalManagement.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public AdminsDTO CurrLogin { get; set; }
        public RelayCommand Authenticate { get; }
        public string Message { get; set; }

        private LoginService loginService;
        public LoginViewModel()
        {
            loginService = new LoginService();
            CurrLogin = new AdminsDTO();
            Authenticate = new RelayCommand(authenticateAdmin);

        }
        public void authenticateAdmin() 
        {
            try
            {
                bool isAuthSuccessful = loginService.AuthenticateAdmin(CurrLogin);
                if (!isAuthSuccessful) 
                {
                    Message = "Érvénytelen bejelentkezés!";
                }
                else
                {
                    LoginWindow lw = new LoginWindow();
                    MainWindow mw = new MainWindow();
                    lw.Close();
                    mw.Show();
                    
                }
            }
            catch (Exception ex)
            {

                 throw ex;
            }
        }
    }
}
