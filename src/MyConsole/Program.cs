using System;
using System.IO;
using System.Reflection;

namespace MyConsole
{
    class Program
    {
        static (string privateKey, string publicKey) GetRsaKey()
        {
            var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var privateKeyPath = Path.Combine(rootPath, "Files", "private.xml");
            var publicKeyPath = Path.Combine(rootPath, "Files", "public.xml");
            var privateKey = File.ReadAllText(privateKeyPath);
            var publicKey = File.ReadAllText(publicKeyPath);

            return (privateKey, publicKey);
        }

        static void Main(string[] args)
        {
            Console.Write("Input Text: ");
            string input = Console.ReadLine();

            var (privateKey, publicKey) = GetRsaKey();
            // var rsaEncoder = new RSAEncoder(privateKey, publicKey);
            var rsaEncoder = new RSAEncoder(privateKey);

            var encryptedInput = rsaEncoder.Encrypt(input);
            Console.WriteLine($"\nEncrypt Input: {encryptedInput}");

            var decryptedInput = rsaEncoder.Decrypt(encryptedInput);
            Console.WriteLine($"Decrypt Input: {decryptedInput}");
            Console.ReadLine();
        }
    }
}
