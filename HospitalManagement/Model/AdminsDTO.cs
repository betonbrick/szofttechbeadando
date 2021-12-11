using HospitalManagement.ViewModel.Base;

namespace HospitalManagement.Model
{
   public class AdminsDTO : BaseViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool isCredentialsFilled() 
        {
            if (Username==null || Password==null)
            {
                return false;
            }
            else if (Username.Equals("") || Password.Equals(""))
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
