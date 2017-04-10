using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Util
{
    public class Seguranca
    {
        public static string CriptyPass(string _login, string _senha)
        {
            //using System.Security.Cryptography; // sempre utilizar esta classe
            StringBuilder senha = new StringBuilder();

            MD5 md5 = MD5.Create();
            byte[] entrada = Encoding.ASCII.GetBytes(_login + "//@" + _senha);
            byte[] hash = md5.ComputeHash(entrada);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                senha.Append(hash[i].ToString("X2"));
            }
            return senha.ToString();
        }

    }
}
