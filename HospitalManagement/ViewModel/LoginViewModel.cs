using BenchmarkDotNet.Running;
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
        public Hashing hashing;

        public RelayCommand Authenticate { get; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        private AuthenticatorService authService;

        public LoginViewModel()
        {
            authService = new AuthenticatorService();
            Authenticate = new RelayCommand(authenticateAdmin);
            hashing = new Hashing();

        }
        public void authenticateAdmin()
        {
            try
            {
                bool isAuthSuccessful = authService.Authenticate(Username, hashing.createMD5Hash(Password));

                if (!isAuthSuccessful)
                {
                    Message = "Érvénytelen bejelentkezés!";
                }
                else
                {
                    Message = "";
                    LoginWindow lw = new LoginWindow();
                    lw.Close();
                    MainWindow mw = new MainWindow();
                    mw.Show();

                    var result = BenchmarkRunner.Run<PeopleService>();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
