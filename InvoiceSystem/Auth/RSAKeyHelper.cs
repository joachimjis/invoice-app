using System;
using System.Security.Cryptography;

namespace InvoiceSystem.Auth
{
    public class RSAKeyHelper
    {
        static bool generated = false;

        static RSAParameters rsa;
        public static RSAParameters GenerateKey()
        {
            if (!generated)
            {
                using (var key = new RSACryptoServiceProvider(2048))
                {
                    rsa = key.ExportParameters(true);
                }
            }
            return rsa;

        }
    }
}
