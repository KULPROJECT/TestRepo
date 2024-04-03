using System.Security.Cryptography;
using System.Text;

namespace ProjectApp.Server.Services
{
    public static class EncryptionTool
    {
        public static string EncryptData(string valueToEncrypt)
        {

            string GenerateSalt()
            {

                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

                byte[] salt = new byte[32];

                crypto.GetBytes(salt);

                return Convert.ToBase64String(salt);

            }

            string EncryptValue(string strvalue)
            {

                string saltValue = GenerateSalt();

                byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValue + strvalue);

                SHA256Managed hashstr = new SHA256Managed();

                byte[] hash = hashstr.ComputeHash(saltedPassword);

                return $"{Convert.ToBase64String(hash)}:{saltValue}";

            }

            return EncryptValue(valueToEncrypt);
        }

        public static bool ValidateEncryptedData(string valueToValidate, string valueFromDatabase)
        {

            string[] arrValues = valueFromDatabase.Split(':');

            string encryptedDbValue = arrValues[0];

            string salt = arrValues[1];

            byte[] saltedValue = Encoding.UTF8.GetBytes(salt + valueToValidate);

            SHA256Managed hashstr = new SHA256Managed();

            byte[] hash = hashstr.ComputeHash(saltedValue);

            string enteredValueToValidate = Convert.ToBase64String(hash);

            return encryptedDbValue.Equals(enteredValueToValidate);
        }

    }
}
