using HospitalManagement.ViewModel.Base;

namespace HospitalManagement.Model
{
    class AdminsDTO : BaseViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
