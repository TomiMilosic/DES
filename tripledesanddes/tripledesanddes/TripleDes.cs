using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace tripledesanddes
{
    public class TripleDes
    {

        TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();

        public TripleDes(string key)
        {
            tripleDes.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDes.Mode = CipherMode.ECB;
            tripleDes.Padding = PaddingMode.PKCS7;
        }

        public void EncryptFile(string FilePath)
        {
            byte[] bytes = File.ReadAllBytes(FilePath);
            byte[] ebyte = tripleDes.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            File.WriteAllBytes(FilePath, ebyte);
        }

        public void DecyrptFile(string FilePath)
        {

            byte[] bytes = File.ReadAllBytes(FilePath);
            byte[] dbyte = tripleDes.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            File.WriteAllBytes(FilePath, dbyte);

        }
    }
}
