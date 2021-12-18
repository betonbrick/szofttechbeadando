// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HospitalManagement.Model;
using NUnit.Framework;

namespace HOspitalManagementTests
{
    [TestFixture]
    public class TestClass
    {
        private HospitalEntities employeeTestEntities;
        private HospitalEntities patientTestEntities;
        private Hashing hash;


        public TestClass()
        {
            employeeTestEntities = new HospitalEntities();
            patientTestEntities = new HospitalEntities();
            hash = new Hashing();
        }
        [Test]
        public void Create_Proper_MD5_Hash()
        {
            string actual = "21232F297A57A5A743894A0E4A801FC3";
            string expected = hash.createMD5Hash("admin");
            Assert.AreEqual(actual, expected);



        }

    }
}
