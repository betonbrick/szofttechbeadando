using HospitalManagement.Model;
using System;
using System.Linq;
using Xunit;

namespace HospitalManagementTests
{
    public class UnitTest1
    {
        Hashing hash = new Hashing();
        [Fact]
        public void Create_MD5Hash_Should_Work()
        {
            string actual = "21232F297A57A5A743894A0E4A801FC3";
            string expected = hash.createMD5Hash("admin");
            Assert.Equal(expected, actual);
        }
    }
}
