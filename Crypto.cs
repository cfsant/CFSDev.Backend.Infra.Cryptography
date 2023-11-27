using System;
using System.Security.Cryptography;
using System.Text;

namespace Base.Infra.Cryptography
{
    public static class Crypto
    {
        public static string SHA512(string data) => ParseByteArrayToSHA512String(ParseByteArrayToSHA512Hash(ParseStringToByteArray(data)));

        private static string ParseByteArrayToSHA512String(byte[] buffer)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }

            return builder.ToString();
        }

        private static byte[] ParseByteArrayToSHA512Hash(byte[] buffer) => new SHA512Managed().ComputeHash(buffer);

        private static byte[] ParseStringToByteArray(string data) => Encoding.UTF8.GetBytes(data);

        static public string EncodeToBase64(string data)
        {
            byte[] textoAsBytes = Encoding.ASCII.GetBytes(data);
            string resultado = System.Convert.ToBase64String(textoAsBytes);
            return resultado;
        }

        static public string DecodeFrom64(string data)
        {
            byte[] dadosAsBytes = System.Convert.FromBase64String(data);
            string resultado = System.Text.ASCIIEncoding.ASCII.GetString(dadosAsBytes);
            return resultado;
        }
    }
}