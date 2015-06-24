namespace BHSoft.BHWeb.Common
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Security;

    public class InEncrypt
    {
        private static byte[] Keys = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };

        public static string Decode(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = BHSoft.BHWeb.Common.Utils.GetSubString(decryptKey, 8, "");
                decryptKey = decryptKey.PadRight(8, ' ');
                byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
                byte[] keys = Keys;
                byte[] buffer = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch
            {
                return "";
            }
        }

        public static string Encode(string encryptString, string encryptKey)
        {
            encryptKey = BHSoft.BHWeb.Common.Utils.GetSubString(encryptKey, 8, "");
            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] keys = Keys;
            byte[] buffer = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }

        public static string Encrypt(string InputString, string pwdType)
        {
            InputString = FormsAuthentication.HashPasswordForStoringInConfigFile(InputString, pwdType);
            return InputString;
        }
    }
}

