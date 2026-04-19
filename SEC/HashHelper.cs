using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SEC
{
    public static class HashHelper
    {
        public static string GenerarHash(string contraseña)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashbytes = sha256.ComputeHash(bytes);
                StringBuilder stringbuilder =  new StringBuilder();
                for(int i = 0; i<hashbytes.Length; i++)
                {
                    stringbuilder.Append(hashbytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }
        public static bool VerificarHash(string texto, string hash)
        {
            string hashdeltexto = GenerarHash(texto);
            return hashdeltexto == hash;
        }
    }
}
