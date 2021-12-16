using HospitalManagement.Model;
using HospitalManagement.ViewModel.Base;

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

                    MainWindow mainWin = new MainWindow();
                    mainWin.Show();
                }
            }
            catch
            {
                Message = "Érvénytelen bejelentkezés!";
            }
        }
    }
}
