using HospitalManagement.Model;
using System;
using Xunit;

namespace HospitalManagementTests
{
    public class UnitTest1
    {
        Hashing hash = new Hashing();
        AuthenticatorService authServ = new AuthenticatorService();
        private PeopleService EmployeeService;
        private PeopleService PatientService;

        [Fact]
        public void Create_MD5Hash_Should_Work()
        {
            string actual = "21232F297A57A5A743894A0E4A801FC3";
            string expected = hash.createMD5Hash("admin");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_MD5Hash_Should_Not_Work()
        {
            string actual = "21232F297A57A5A743894A0E4A801FC333";
            string expected = hash.createMD5Hash("admin");
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void Login_Successful()
        {
            string username = "admin";
            string password = "admin";
            bool expected = authServ.Authenticate(username, hash.createMD5Hash(password));
            Assert.True(expected);
        }

        [Fact]
        public void Login_Unsuccessful_With_Wrong_Password()
        {
            string username = "admin";
            string password = "adminnn";
            bool expected = authServ.Authenticate(username, hash.createMD5Hash(password));
            Assert.False(expected);
        }


        [Fact]
        public void Login_Unsuccessful_With_Wrong_Username()
        {
            string username = "adminnn";
            string password = "admin";
            bool expected = authServ.Authenticate(username, hash.createMD5Hash(password));
            Assert.False(expected);
        }

        [Fact]
        public void Login_Unsuccessful_Empty_Fields()
        {
            string username = "";
            string password = "";
            bool expected = authServ.Authenticate(username, hash.createMD5Hash(password));
            Assert.False(expected);
        }

        [Fact]
        public void Add_Employee_Should_Work()
        {
            bool isSaved = false;
            EmployeeService = new PeopleService();
            EmployeeDTO employee = new EmployeeDTO();

            employee.Id = 1000;
            employee.Name = "Nagy Ferenc";
            employee.Age = 50;
            employee.Address = "Budapest";
            employee.Email = "nagyferenc@gmail.com";
            employee.Phone = 207894561;
            employee.Speciality = "Sebész";
            employee.Salary = 700000;

            isSaved = EmployeeService.addEmployee(employee, true);

            Assert.True(isSaved);
        }

        [Fact]
        public void Update_Employee_Should_Work()
        {
            bool isUpdated = false;
            EmployeeService = new PeopleService();
            EmployeeDTO employee = new EmployeeDTO();

            employee.Id = 1000;
            employee.Name = "Nagy Ferenc";
            employee.Age = 50;
            employee.Address = "Budapest";
            employee.Email = "nagyferenc@gmail.com";
            employee.Phone = 207894561;
            employee.Speciality = "Urológus";
            employee.Salary = 800000;

            isUpdated = EmployeeService.updateEmployee(employee, false);

            Assert.True(isUpdated);
        }

        [Fact]
        public void Delete_Employee_Should_Work()
        {
            bool isDeleted = false;
            EmployeeService = new PeopleService();
            EmployeeDTO employee = new EmployeeDTO();

            employee.Id = 1000;

            isDeleted = EmployeeService.deleteEmployee(employee.Id);

            Assert.True(isDeleted);
        }

        [Fact]
        public void Search_Employee_Should_Not_Be_Null()
        {
            EmployeeService = new PeopleService();
            EmployeeDTO employee = EmployeeService.searchEmployee("Dr. Varga Mónika");

            Assert.NotNull(employee);
        }

        [Fact]
        public void Search_Employee_Should_Be_Null()
        {
            EmployeeService = new PeopleService();
            EmployeeDTO employee = EmployeeService.searchEmployee("Dr. Szőke András");

            Assert.Null(employee);
        }












        [Fact]
        public void Add_Patient_Should_Work()
        {
            bool isSaved = false;
            PatientService = new PeopleService();
            PatientDTO patient = new PatientDTO();

            patient.Id = 1000;
            patient.Name = "Kénes István";
            patient.Age = 38;
            patient.Address = "Budapest";
            patient.Email = "kenesistvan@gmail.com";
            patient.Class = "Sebészet";
            patient.Phone = 201234567;

            isSaved = PatientService.addPatient(patient);

            Assert.True(isSaved);
        }

        [Fact]
        public void Update_Patient_Should_Work()
        {
            bool isUpdated = false;
            PatientService = new PeopleService();
            PatientDTO patient = new PatientDTO();

            patient.Id = 1000;
            patient.Name = "Kénes István";
            patient.Age = 40;
            patient.Address = "Budapest";
            patient.Email = "nagyferenc22@gmail.com";
            patient.Class = "Urológia";
            patient.Phone = 207894561;

            isUpdated = PatientService.updatePatient(patient);

            Assert.True(isUpdated);
        }

        [Fact]
        public void Delete_Patient_Should_Work()
        {
            bool isDeleted = false;
            PatientService = new PeopleService();
            PatientDTO patient = new PatientDTO();

            patient.Id = 1000;

            isDeleted = PatientService.deletePatient(patient.Id);

            Assert.True(isDeleted);
        }
    }
}
