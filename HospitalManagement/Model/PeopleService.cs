using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model
{
    //[MemoryDiagnoser]
    public class PeopleService
    {

        private HospitalEntities employeeEntities;
        private HospitalEntities patientEntities;

        public PeopleService()
        {
            employeeEntities = new HospitalEntities();
            patientEntities = new HospitalEntities();
        }

        // EMPLOYEE TÁBLA ÖSSZES ELEME
        //[Benchmark]
        public List<EmployeeDTO> getAllEmployees()
        {
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();

            try
            {
                var employees = from employee in employeeEntities.Employees select employee;

                foreach (var employee in employees)
                {
                    employeeDTOs.Add(new EmployeeDTO
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Age = employee.Age,
                        Occupation = employee.Occupation,
                        Address = employee.Address,
                        Email = employee.Email,
                        Phone = employee.Phone,
                        Speciality = employee.Speciality,
                        Salary = employee.Salary
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeeDTOs;
        }

        // PATIENT TÁBLA ÖSSZES ELEME
        //[Benchmark]
        public List<PatientDTO> getAllPatients()
        {
            List<PatientDTO> patientDTOs = new List<PatientDTO>();

            try
            {
                var patients = from patient in patientEntities.Patients select patient;

                foreach (var patient in patients)
                {
                    patientDTOs.Add(new PatientDTO
                    {
                        Id = patient.Id,
                        Name = patient.Name,
                        Age = patient.Age,
                        Class = patient.Class,
                        Address = patient.Address,
                        Email = patient.Email,
                        Phone = patient.Phone
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patientDTOs;
        }

        // EMPLOYEE HOZZÁADÁSA
        public bool addEmployee(EmployeeDTO newEmployee, bool isChecked)
        {
            bool isEmpAdded = false;

            if (newEmployee.Id == 0)
            {
                throw new ArgumentException("Az azonosító nem lehet 0.");
            }
            else if (newEmployee.Age < 16 || newEmployee.Age > 64)
            {
                throw new ArgumentException("Az alkalmazott életkora nem megfelelő.");
            }
            else
            {
                try
                {
                    var employee = new Employees();

                    employee.Id = newEmployee.Id;
                    employee.Name = newEmployee.Name;
                    employee.Age = newEmployee.Age;

                    if (isChecked)
                    {
                        employee.Occupation = "Nővér";
                        employee.Speciality = "-";
                    }
                    else
                    {
                        employee.Occupation = "Orvos";
                        employee.Speciality = newEmployee.Speciality;
                    }

                    employee.Address = newEmployee.Address;
                    employee.Email = newEmployee.Email;
                    employee.Phone = newEmployee.Phone;

                    employee.Salary = newEmployee.Salary;

                    employeeEntities.Employees.Add(employee);
                    var numberOfRowsAffected = employeeEntities.SaveChanges();
                    isEmpAdded = numberOfRowsAffected > 0;
                }
                catch (Exception)
                {
                    throw new ArgumentException("Van már ilyen azonosító a listában.");
                }

                return isEmpAdded;
            }
        }

        // PATIENT HOZZÁADÁSA
        public bool addPatient(PatientDTO newPatient)
        {
            bool isPatAdded = false;

            if (newPatient.Id == 0)
            {
                throw new ArgumentException("Az azonosító nem lehet 0.");
            }
            else
            {
                try
                {
                    var patient = new Patients();

                    patient.Id = newPatient.Id;
                    patient.Name = newPatient.Name;
                    patient.Age = newPatient.Age;
                    patient.Class = newPatient.Class;
                    patient.Address = newPatient.Address;
                    patient.Email = newPatient.Email;
                    patient.Phone = newPatient.Phone;

                    patientEntities.Patients.Add(patient);
                    var numberOfRowsAffected = patientEntities.SaveChanges();
                    isPatAdded = numberOfRowsAffected > 0;
                }
                catch (Exception)
                {
                    throw new ArgumentException("Van már ilyen azonosító a listában.");
                }

                return isPatAdded;
            }
        }

        // EMPLOYEE FRISSÍTÉSE
        public bool updateEmployee(EmployeeDTO employeeUpdate, bool isOccupationChanged)
        {
            bool isEmpUpdated = false;

            if (employeeUpdate.Id == 0)
            {
                throw new ArgumentException("Az azonosító nem lehet 0.");
            }
            else
            {
                try
                {
                    var employee = employeeEntities.Employees.Find(employeeUpdate.Id);

                    employee.Name = employeeUpdate.Name;
                    employee.Age = employeeUpdate.Age;
                    if (isOccupationChanged)
                    {
                        employee.Occupation = "Nővér";
                        employee.Speciality = "-";
                    }
                    else
                    {
                        employee.Occupation = "Orvos";
                        employee.Speciality = employeeUpdate.Speciality;

                    }
                    employee.Address = employeeUpdate.Address;
                    employee.Email = employeeUpdate.Email;
                    employee.Phone = employeeUpdate.Phone;

                    employee.Salary = employeeUpdate.Salary;

                    var numberOfRowsAffected = employeeEntities.SaveChanges();
                    isEmpUpdated = numberOfRowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return isEmpUpdated;
            }
        }

        // PATIENT FRISSÍTÉSE
        public bool updatePatient(PatientDTO patientUpdate)
        {
            bool isPatUpdated = false;

            if (patientUpdate.Id == 0)
            {
                throw new ArgumentException("Az azonosító nem lehet 0.");
            }
            else
            {
                try
                {
                    var patient = patientEntities.Patients.Find(patientUpdate.Id);

                    patient.Name = patientUpdate.Name;
                    patient.Age = patientUpdate.Age;
                    patient.Class = patientUpdate.Class;
                    patient.Address = patientUpdate.Address;
                    patient.Email = patientUpdate.Email;
                    patient.Phone = patientUpdate.Phone;

                    var numberOfRowsAffected = patientEntities.SaveChanges();
                    isPatUpdated = numberOfRowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return isPatUpdated;
            }
        }

        // EMPLOYEE TÖRLÉSE
        public bool deleteEmployee(int id)
        {
            bool isEmpDeleted = false;

            if (id == 0)
            {
                throw new ArgumentException("Az azonosító nem lehet 0.");
            }
            else
            {
                try
                {
                    var employee = employeeEntities.Employees.Find(id);

                    employeeEntities.Employees.Remove(employee);

                    var numberOfRowsEffected = employeeEntities.SaveChanges();
                    isEmpDeleted = numberOfRowsEffected > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return isEmpDeleted;
            }
        }

        // PATIENT TÖRLÉSE
        public bool deletePatient(int id)
        {
            bool isPatDeleted = false;

            if (id == 0)
            {
                throw new ArgumentException("Az azonosító nem lehet 0.");
            }
            else
            {
                try
                {
                    var patient = patientEntities.Patients.Find(id);

                    patientEntities.Patients.Remove(patient);

                    var numberOfRowsEffected = patientEntities.SaveChanges();
                    isPatDeleted = numberOfRowsEffected > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return isPatDeleted;
            }
        }

        // EMPLOYEE KERESÉSE
        public EmployeeDTO searchEmployee(string employeeName)
        {
            EmployeeDTO employeeDTO = null;

            try
            {
                var employee = employeeEntities.Employees.Where(search => search.Name == employeeName).FirstOrDefault();

                if (employee != null)
                {
                    employeeDTO = new EmployeeDTO()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Age = employee.Age,
                        Occupation = employee.Occupation,
                        Address = employee.Address,
                        Email = employee.Email,
                        Phone = employee.Phone,
                        Speciality = employee.Speciality,
                        Salary = employee.Salary
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeeDTO;
        }

        // PATIENT KERESÉSE
        public PatientDTO searchPatient(string patientName)
        {
            PatientDTO patientDTO = null;

            try
            {
                var patient = patientEntities.Patients.Where(search => search.Name == patientName).FirstOrDefault();

                if (patient != null)
                {
                    patientDTO = new PatientDTO()
                    {
                        Id = patient.Id,
                        Name = patient.Name,
                        Age = patient.Age,
                        Class = patient.Class,
                        Address = patient.Address,
                        Email = patient.Email,
                        Phone = patient.Phone
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patientDTO;
        }

        // EMPLOYEE MEGSZÁMLÁLÁSA
        public int countEmployees()
        {
            int count = 0;

            try
            {
                var employees = from employee in employeeEntities.Employees select employee;
                foreach (var employee in employees)
                {
                    count++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return count;
        }

        // PATIENT MEGSZÁMLÁLÁSA
        public int countPatients()
        {
            int count = 0;

            try
            {
                var patients = from patient in patientEntities.Patients select patient;
                foreach (var employee in patients)
                {
                    count++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return count;
        }
    }
}
