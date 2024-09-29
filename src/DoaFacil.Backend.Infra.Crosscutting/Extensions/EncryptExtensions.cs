using System.Security.Cryptography;
using System.Text;

namespace DoaFacil.Backend.Infra.Crosscutting.Extensions
{
    public static class EncryptExtensions
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("a1b2c3d4e5f6g7h8"); 
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1a2b3c4d5e6f7g8h"); 

        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using MemoryStream ms = new();
            using CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using (StreamWriter sw = new(cs))
            {
                sw.Write(plainText);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            byte[] buffer = Convert.FromBase64String(cipherText);

            using MemoryStream ms = new(buffer);
            using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader sr = new(cs);
            return sr.ReadToEnd();
        }
    }
}
