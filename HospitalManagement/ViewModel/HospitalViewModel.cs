using HospitalManagement.Model;
using HospitalManagement.ViewModel.Base;
using System;
using System.Collections.ObjectModel;

namespace HospitalManagement.ViewModel
{
    public class HospitalViewModel : BaseViewModel
    {
        public ObservableCollection<EmployeeDTO> Employees { get; set; }
        public ObservableCollection<PatientDTO> Patients { get; set; }

        public EmployeeDTO CurrEmp { get; set; }
        public PatientDTO CurrPat { get; set; }

        public RelayCommand SaveEmp { get; }
        public RelayCommand UpdateEmp { get; }
        public RelayCommand DeleteEmp { get; }
        public RelayCommand SearchEmp { get; }

        public RelayCommand SavePat { get; }
        public RelayCommand UpdatePat { get; }
        public RelayCommand DeletePat { get; }
        public RelayCommand SearchPat { get; }

        public RelayCommand PrintData { get; }

        public bool Occupation { get; set; }

        public int CountEmp
        {
            get
            {
                return (int)EmployeeService.countEmployees();
            }
            set
            {
                EmployeeService.countEmployees();
            }
        }

        public int CountPat
        {
            get
            {
                return (int)EmployeeService.countPatients();
            }
            set
            {
                EmployeeService.countEmployees();
            }
        }

        public string Message { get; set; }

        private PeopleService EmployeeService;
        private PeopleService PatientService;

        public HospitalViewModel()
        {
            EmployeeService = new PeopleService();
            PatientService = new PeopleService();

            loadAllEmployees();
            loadAllPatients();

            CurrEmp = new EmployeeDTO();
            CurrPat = new PatientDTO();

            SaveEmp = new RelayCommand(saveEmp);
            UpdateEmp = new RelayCommand(updateEmp);
            DeleteEmp = new RelayCommand(deleteEmp);
            SearchEmp = new RelayCommand(searchEmp);


            SavePat = new RelayCommand(savePat);
            UpdatePat = new RelayCommand(updatePat);
            DeletePat = new RelayCommand(deletePat);
            SearchPat = new RelayCommand(searchPat);
            PrintData = new RelayCommand(printData);
        }

        // ÖSSZES EMPLOYEE
        public void loadAllEmployees()
        {
            Employees = new ObservableCollection<EmployeeDTO>(EmployeeService.getAllEmployees());
        }

        // ÖSSZES PATIENT
        public void loadAllPatients()
        {
            Patients = new ObservableCollection<PatientDTO>(PatientService.getAllPatients());
        }

        // SAVE EMPLOYEE
        public void saveEmp()
        {
            try
            {
                bool isEmpSaved = false;

                if (Occupation)
                {
                    isEmpSaved = EmployeeService.addEmployee(CurrEmp, Occupation);
                }
                else
                {
                    isEmpSaved = EmployeeService.addEmployee(CurrEmp, Occupation);
                }

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

        // SAVE PATIENT
        public void savePat()
        {
            try
            {
                bool isPatSaved = PatientService.addPatient(CurrPat);

                loadAllPatients();

                if (isPatSaved)
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

        // UPDATE EMPLOYEE
        public void updateEmp()
        {
            try
            {
                bool isEmpUpdated = false;

                if (!Occupation)
                {
                    isEmpUpdated = EmployeeService.updateEmployee(CurrEmp, Occupation);
                }
                else
                {
                    isEmpUpdated = EmployeeService.updateEmployee(CurrEmp, Occupation);
                }

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

        // UPDATE PATIENT
        public void updatePat()
        {
            try
            {
                bool isPatUpdated = PatientService.updatePatient(CurrPat);

                if (isPatUpdated)
                {
                    Message = "Sikeres módosítás!";

                    loadAllPatients();
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

        // DELETE EMPLOYEE
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

        // DELETE PATIENT
        public void deletePat()
        {
            try
            {
                bool isPatDeleted = PatientService.deletePatient(CurrPat.Id);

                if (isPatDeleted)
                {
                    Message = "Sikeres törlés!";

                    loadAllPatients();
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

        // SEARCH EMPLOYEE
        public void searchEmp()
        {
            try
            {
                EmployeeDTO employee = EmployeeService.searchEmployee(CurrEmp.Name);

                if (employee != null)
                {
                    CurrEmp.Id = employee.Id;
                    CurrEmp.Name = employee.Name;
                    CurrEmp.Age = employee.Age;
                    CurrEmp.Occupation = employee.Occupation;
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

        // SEARCH PATIENT
        public void searchPat()
        {
            try
            {
                PatientDTO patient = PatientService.searchPatient(CurrPat.Name);

                if (patient != null)
                {
                    CurrPat.Id = patient.Id;
                    CurrPat.Name = patient.Name;
                    CurrPat.Age = patient.Age;
                    CurrPat.Class = patient.Class;
                    CurrPat.Address = patient.Address;
                    CurrPat.Email = patient.Email;
                    CurrPat.Phone = patient.Phone;
                }
                else
                {
                    Message = "Nincs ilyen beteg.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void printData()
        {
            DataPrinting dp = new DataPrinting();
            dp.OnDataGridPrinting();
        }
    }
}
