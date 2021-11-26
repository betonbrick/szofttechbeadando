using HospitalManagement.ViewModel.Base;

namespace HospitalManagement.Model
{
    public class PatientDTO : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
    }
}
