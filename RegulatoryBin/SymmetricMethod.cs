using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SymmetricMethod
{
    private string Key = "Guz(%&hj7x89H$yuBI0456FthrH3&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";
    private SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();

    public string Decrypto(string Source)
    {
        byte[] buffer = Convert.FromBase64String(Source);
        MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
        this.mobjCryptoService.Key = this.GetLegalKey();
        this.mobjCryptoService.IV = this.GetLegalIV();
        ICryptoTransform transform = this.mobjCryptoService.CreateDecryptor();
        CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
        StreamReader reader = new StreamReader(stream2);
        return reader.ReadToEnd();
    }

    public string Encrypto(string Source)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(Source);
        MemoryStream stream = new MemoryStream();
        this.mobjCryptoService.Key = this.GetLegalKey();
        this.mobjCryptoService.IV = this.GetLegalIV();
        ICryptoTransform transform = this.mobjCryptoService.CreateEncryptor();
        CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
        stream2.Write(bytes, 0, bytes.Length);
        stream2.FlushFinalBlock();
        stream.Close();
        return Convert.ToBase64String(stream.ToArray());
    }

    private byte[] GetLegalIV()
    {
        string s = "E4ghj*Ghg7!rNIfb&2013GUY86Gfghhr#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
        this.mobjCryptoService.GenerateIV();
        int length = this.mobjCryptoService.IV.Length;
        if (s.Length > length)
        {
            s = s.Substring(0, length);
        }
        else if (s.Length < length)
        {
            s = s.PadRight(length, ' ');
        }
        return Encoding.ASCII.GetBytes(s);
    }

    private byte[] GetLegalKey()
    {
        string key = this.Key;
        this.mobjCryptoService.GenerateKey();
        int length = this.mobjCryptoService.Key.Length;
        if (key.Length > length)
        {
            key = key.Substring(0, length);
        }
        else if (key.Length < length)
        {
            key = key.PadRight(length, ' ');
        }
        return Encoding.ASCII.GetBytes(key);
    }
}

