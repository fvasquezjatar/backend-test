using System;
using System.Security.Cryptography;
using System.Text;

namespace IngswDev.Extensions
{
    public static class SecurityExtension
    {
        public static string ComputeHash(this string s)
        {
            string stringHash;
            using (var sha512 = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(s);
                var result = sha512.ComputeHash(bytes);
                stringHash = Convert.ToBase64String(result);
            }
            return stringHash;
        }

        public static string EncodeBase64(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            var byteArray = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(byteArray);
        }

        public static string DecodeFromBase64(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            var byteArray = Convert.FromBase64String(s);
            return Encoding.UTF8.GetString(byteArray);
        }
    }
}
