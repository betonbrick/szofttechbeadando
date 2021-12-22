using System.Security.Cryptography;
using System.Text;

namespace HospitalManagement.Model
{
    public class Hashing
    {
        public string createMD5Hash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2"));

                }

                return stringBuilder.ToString();
            }
        }
    }
}
