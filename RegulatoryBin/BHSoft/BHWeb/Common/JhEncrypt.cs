namespace BHSoft.BHWeb.Common
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class JhEncrypt
    {
        public static byte[] Decrypt(byte[] encrypted)
        {
            byte[] bytes = Encoding.Default.GetBytes("JASONHEUNG");
            return Decrypt(encrypted, bytes);
        }

        public static string Decrypt(string original)
        {
            return Decrypt(original, "JASONHEUNG", Encoding.Default);
        }

        public static string Decrypt(string original, string key)
        {
            return Decrypt(original, key, Encoding.Default);
        }

        public static string Decrypt(string original, Encoding encoding)
        {
            return Decrypt(original, "JASONHEUNG", encoding);
        }

        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider {
                Key = MakeMD5(key),
                Mode = CipherMode.ECB
            };
            return provider.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buffer = Convert.FromBase64String(encrypted);
            byte[] bytes = Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buffer, bytes));
        }

        public static string Encrypt(string original)
        {
            return Encrypt(original, "JASONHEUNG");
        }

        public static byte[] Encrypt(byte[] original)
        {
            byte[] bytes = Encoding.Default.GetBytes("JASONHEUNG");
            return Encrypt(original, bytes);
        }

        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider {
                Key = MakeMD5(key),
                Mode = CipherMode.ECB
            };
            return provider.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        public static string Encrypt(string original, string key)
        {
            byte[] bytes = Encoding.Default.GetBytes(original);
            byte[] buffer2 = Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(bytes, buffer2));
        }

        public static byte[] MakeMD5(byte[] original)
        {
            return new MD5CryptoServiceProvider().ComputeHash(original);
        }
    }
}

