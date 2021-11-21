using HospitalManagement.Model;
using HospitalManagement.ViewModel.Base;
using System;
using System.Collections.ObjectModel;

namespace HospitalManagement.ViewModel
{
    public class PatientViewModel : BaseViewModel
    {
        public ObservableCollection<PatientDTO> Patients { get; set; }
        public PatientDTO CurrPat { get; set; }

        public RelayCommand SavePat { get; }
        public RelayCommand UpdatePat { get; }
        public RelayCommand DeletePat { get; }
        public RelayCommand SearchPat { get; }

        public string Message { get; set; }

        private PeopleService PatientService;

        public PatientViewModel()
        {
            PatientService = new PeopleService();

            loadAllPatients();

            CurrPat = new PatientDTO();

            SavePat = new RelayCommand(savePat);
            UpdatePat = new RelayCommand(updatePat);
            DeletePat = new RelayCommand(deletePat);
            SearchPat = new RelayCommand(searchPat);
        }

        public void loadAllPatients()
        {
            Patients = new ObservableCollection<PatientDTO>(PatientService.getAllPatients());
        }

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

        public void updatePat()
        {
            try
            {
                // itt eredeiteld VAR van a BOOL helyett
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

        public void searchPat()
        {
            try
            {
                PatientDTO patient = PatientService.searchPatient(CurrPat.Id);

                if (patient != null)
                {
                    CurrPat.Id = patient.Id;
                    CurrPat.Name = patient.Name;
                    CurrPat.Age = patient.Age;
                    CurrPat.Settlement = patient.Settlement;
                    CurrPat.Address = patient.Address;
                    CurrPat.Email = patient.Email;
                    CurrPat.Phone = patient.Phone;
                }
                else
                {
                    Message = "Ilyen beteg nincs.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
