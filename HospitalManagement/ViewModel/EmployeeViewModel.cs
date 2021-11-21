using HospitalManagement.Model;
using HospitalManagement.ViewModel.Base;
using System;
using System.Collections.ObjectModel;

namespace HospitalManagement.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        public ObservableCollection<EmployeeDTO> Employees { get; set; }
        public EmployeeDTO CurrEmp { get; set; }

        public RelayCommand SaveEmp { get; }
        public RelayCommand UpdateEmp { get; }
        public RelayCommand DeleteEmp { get; }
        public RelayCommand SearchEmp { get; }
        public RelayCommand CountEmp { get; }

        public string Message { get; set; }

        private PeopleService EmployeeService;

        public EmployeeViewModel()
        {
            EmployeeService = new PeopleService();

            loadAllEmployees();

            CurrEmp = new EmployeeDTO();

            SaveEmp = new RelayCommand(saveEmp);
            UpdateEmp = new RelayCommand(updateEmp);
            DeleteEmp = new RelayCommand(deleteEmp);
            SearchEmp = new RelayCommand(searchEmp);
            CountEmp = new RelayCommand(countEmp);
        }

        public void loadAllEmployees()
        {
            Employees = new ObservableCollection<EmployeeDTO>(EmployeeService.getAllEmployees());
        }

        public void saveEmp()
        {
            try
            {
                bool isEmpSaved = EmployeeService.addEmployee(CurrEmp);

                loadAllEmployees();

                if (isEmpSaved)
                {
                    Message = "Sikeres mentés!";
                }
                else
                {
                    Message = "Sikertelen mentés.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void updateEmp()
        {
            try
            {
                // itt eredeiteld VAR van a BOOL helyett
                bool isEmpUpdated = EmployeeService.updateEmployee(CurrEmp);

                if (isEmpUpdated)
                {
                    Message = "Sikeres módosítás!";

                    loadAllEmployees();
                }
                else
                {
                    Message = "Sikertelen módosítás.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void deleteEmp()
        {
            try
            {
                bool isEmpDeleted = EmployeeService.deleteEmployee(CurrEmp.Id);

                if (isEmpDeleted)
                {
                    Message = "Sikeres törlés!";

                    loadAllEmployees();
                }
                else
                {
                    Message = "Sikertelen törlés.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void searchEmp()
        {
            try
            {
                EmployeeDTO employee = EmployeeService.searchEmployee(CurrEmp.Id);

                if (employee != null)
                {
                    CurrEmp.Id = employee.Id;
                    CurrEmp.Name = employee.Name;
                    CurrEmp.Age = employee.Age;
                    CurrEmp.Settlement = employee.Settlement;
                    CurrEmp.Address = employee.Address;
                    CurrEmp.Email = employee.Email;
                    CurrEmp.Phone = employee.Phone;
                    CurrEmp.Speciality = employee.Speciality;
                    CurrEmp.Salary = employee.Salary;
                }
                else
                {
                    Message = "Nincs ilyen alkalmazott.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void countEmp()
        {
            try
            {
                int countEmp = EmployeeService.countAllEmployees();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
