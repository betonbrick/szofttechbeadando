using HospitalManagement.ViewModel.Base;

namespace HospitalManagement.Model
{
    public class EmployeeDTO : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Speciality { get; set; }
        public int Salary { get; set; }
    }
}
