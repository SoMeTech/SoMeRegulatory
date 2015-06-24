namespace SoMeTech.CommonDll
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class SMLicense
    {
        public static string HEDET(string etStr)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);
            byte[] buffer = Convert.FromBase64String(etStr);
            string str = null;
            Rijndael rijndael = Rijndael.Create();
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write))
                    {
                        stream2.Write(buffer, 0, buffer.Length);
                        stream2.FlushFinalBlock();
                        str = Encoding.UTF8.GetString(stream.ToArray());
                    }
                }
            }
            catch
            {
            }
            rijndael.Clear();
            return str;
        }

        public static string HRDet(string etStr, bool returnNull)
        {
            string str = HEDET(etStr);
            if (returnNull)
            {
                return str;
            }
            if (str != null)
            {
                return str;
            }
            return string.Empty;
        }

        public static string HRET(string plainStr)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);
            byte[] buffer = Encoding.UTF8.GetBytes(plainStr);
            string str = null;
            Rijndael rijndael = Rijndael.Create();
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write))
                    {
                        stream2.Write(buffer, 0, buffer.Length);
                        stream2.FlushFinalBlock();
                        str = Convert.ToBase64String(stream.ToArray());
                    }
                }
            }
            catch
            {
            }
            rijndael.Clear();
            return str;
        }

        public static string HRET(string plainStr, bool returnNull)
        {
            string str = HRET(plainStr);
            if (returnNull)
            {
                return str;
            }
            if (str != null)
            {
                return str;
            }
            return string.Empty;
        }

        private static string IV
        {
            get
            {
                return @"L+\~f4,Ir)b$=pkf";
            }
        }

        private static string Key
        {
            get
            {
                return ")O[NB]6,YF}+efacj{+oESb9d8>Z'e9M";
            }
        }
    }
}

