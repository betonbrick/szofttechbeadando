using HospitalManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace HospitalManagementTests
{
    public class UnitTest1
    {
        Hashing hash = new Hashing();
        AuthenticatorService authServ = new AuthenticatorService();
        private PeopleService EmployeeService;

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
        public void Delete_Employee_Should_Work()
        {
            bool isDeleted = false;
            EmployeeService = new PeopleService();
            EmployeeDTO employee = new EmployeeDTO();

            employee.Id = 1000;

            isDeleted = EmployeeService.deleteEmployee(employee.Id);

            Assert.True(isDeleted);
        }
    }
}
