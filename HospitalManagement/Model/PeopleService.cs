using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model
{
    public class PeopleService
    {

        private hospitalmgmntEntities employeeEntities;
        private hospitalmgmntEntities patientEntities;

        public PeopleService()
        {
            employeeEntities = new hospitalmgmntEntities();
            patientEntities = new hospitalmgmntEntities();
        }

        // EMPLOYEE TÁBLA ÖSSZES ELEME
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
                        Settlement = employee.Settlement,
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
                        Settlement = patient.Settlement,
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
        public bool addEmployee(EmployeeDTO newEmployee)
        {
            bool isEmpAdded = false;
            if (newEmployee.Age < 16 || newEmployee.Age > 64)
                throw new ArgumentException("Az alkalmazott életkora nem megfelelő.");

            try
            {
                var employee = new Employees();
                employee.Id = newEmployee.Id;
                employee.Name = newEmployee.Name;
                employee.Age = newEmployee.Age;
                employee.Settlement = newEmployee.Settlement;
                employee.Address = newEmployee.Address;
                employee.Email = newEmployee.Email;
                employee.Phone = newEmployee.Phone;
                employee.Speciality = newEmployee.Speciality;
                employee.Salary = newEmployee.Salary;

                employeeEntities.Employees.Add(employee);
                var numberOfRowsAffected = employeeEntities.SaveChanges();
                isEmpAdded = numberOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isEmpAdded;
        }

        // PATIENT HOZZÁADÁSA
        public bool addPatient(PatientDTO newPatient)
        {
            bool isPatAdded = false;
            try
            {
                var patient = new Patients();
                patient.Id = newPatient.Id;
                patient.Name = newPatient.Name;
                patient.Age = newPatient.Age;
                patient.Settlement = newPatient.Settlement;
                patient.Address = newPatient.Address;
                patient.Email = newPatient.Email;
                patient.Phone = newPatient.Phone;

                patientEntities.Patients.Add(patient);
                var numberOfRowsAffected = patientEntities.SaveChanges();
                isPatAdded = numberOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isPatAdded;
        }
    }
}
