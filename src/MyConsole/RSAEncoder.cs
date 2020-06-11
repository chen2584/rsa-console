using System;
using System.Security.Cryptography;
using System.Text;

public class RSAEncoder
{
    RSACryptoServiceProvider _rsa = new RSACryptoServiceProvider();
    public RSAEncoder(string asymmetricKeyXml)
    {
        _rsa = new RSACryptoServiceProvider();
        _rsa.FromXmlString(asymmetricKeyXml);
    }

    public string Encrypt(string plainText)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedText = _rsa.Encrypt(plainTextBytes, false);

        return Convert.ToBase64String(encryptedText);
    }

    public string Decrypt(string encryptedText)
    {
        byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
        byte[] decryptedTextBytes = _rsa.Decrypt(encryptedTextBytes, false);

        return Encoding.UTF8.GetString(decryptedTextBytes);
    }
}