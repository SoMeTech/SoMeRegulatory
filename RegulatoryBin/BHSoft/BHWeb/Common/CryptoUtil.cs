namespace BHSoft.BHWeb.Common
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class CryptoUtil
    {
        private static byte[] CryptIV = Encoding.UTF8.GetBytes("TheFlowerShop012");
        private static byte[] CryptKey = Encoding.UTF8.GetBytes("HailsoftTheFlowerShop0123456789A");

        public static string Decrypt(string cryptText)
        {
            string s = cryptText;
            if ((cryptText == null) || (cryptText.Length == 0))
            {
                return "";
            }
            RijndaelManaged managed = new RijndaelManaged();
            byte[] cryptKey = CryptKey;
            byte[] cryptIV = CryptIV;
            byte[] buffer = Convert.FromBase64String(s);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, managed.CreateDecryptor(cryptKey, cryptIV), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static string Encrypt(string cryptText)
        {
            string s = cryptText;
            if ((cryptText == null) || (cryptText.Length == 0))
            {
                return "";
            }
            RijndaelManaged managed = new RijndaelManaged();
            byte[] cryptKey = CryptKey;
            byte[] cryptIV = CryptIV;
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, managed.CreateEncryptor(cryptKey, cryptIV), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }
    }
}

