using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace tripledesanddes
{
    public class DES
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();


        public DES(string key)
        {
            des.Key = UTF8Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
        }



        public void EncryptFile(string FilePath) 
        {
            byte[] bytes = File.ReadAllBytes(FilePath);
            byte[] ebyte = des.CreateEncryptor().TransformFinalBlock(bytes,0,bytes.Length);
            File.WriteAllBytes(FilePath, ebyte);
        }

        public void DecryptFile(string FilePath)
        {
            byte[] bytes = File.ReadAllBytes(FilePath);
            byte[] ebyte = des.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            File.WriteAllBytes(FilePath, ebyte);

        }

       
    }
}
