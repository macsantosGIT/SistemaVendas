using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Util
{
    public class Validacao
    {
        public static bool IsCnpj(string cnpj)
        {
            //Variaveis
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            // Caso coloque todos os numeros iguais
            switch (cnpj)
            {
                case "11111111111111":
                    return false;
                case "00000000000000":
                    return false;
                case "22222222222222":
                    return false;
                case "33333333333333":
                    return false;
                case "44444444444444":
                    return false;
                case "55555555555555":
                    return false;
                case "66666666666666":
                    return false;
                case "77777777777777":
                    return false;
                case "88888888888888":
                    return false;
                case "99999999999999":
                    return false;
            }

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool IsCpf(string cpf)
        {
            //Variaveis
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool ValidaEmail(string Valor)
        {
            if (string.IsNullOrEmpty(Valor))
            {
                return true;
            }

            bool Valido = false;

            Regex regEx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.IgnoreCase);

            Valido = regEx.IsMatch(Valor);

            return Valido;
        }

        public static string RetiraMascara(string pCampo)
        {
            string result = "";
            result = pCampo.Replace(".", "").Replace("-", "").Replace("/", "").Replace(",","");

            return result;
        }

        public static string MascaraCnpjCpf(string pCnpjCpf)
        {
            string result = "";
            if (pCnpjCpf.Length == 14)
            {
                result = pCnpjCpf.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }

            if (pCnpjCpf.Length == 11)
            {
                result = pCnpjCpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }

            if ((pCnpjCpf.Length != 11) && (pCnpjCpf.Length != 14))
            {
                result = pCnpjCpf;
            }

            return result;
        }

        public static string MascaraTelefone(string pTelefone)
        {
            string result = "";

            if (pTelefone != "0")
            {
                result = pTelefone.Insert(4, "-");
            }

            return result;
        }

        public static string MascaraCelular(string pCelular)
        {
            string result = "";
            if (pCelular != "0")
            {
                if (pCelular.Length < 9)
                {
                    result = pCelular.Insert(4, "-");
                }
                else
                {
                    result = pCelular.Insert(5, "-");
                }
            }

            return result;
        }

        public static string MascaraCep(string pCep)
        {
            string result = "";

            pCep = pCep.PadLeft(8, '0');

            result = pCep.Insert(5, "-");

            return result;
        }

        public static string MascaraData(string pData)
        {
            string resutl = "";
            
            resutl = pData.Substring(0, 2) + "/" + pData.Substring(2, 2) + "/" + pData.Substring(4, 4);

            return resutl;
        }

        public static string MascaraDecimal(string pValor)
        {
            string result = "";

            if(pValor.Length <= 2)
            {
                result = "0," + pValor;
            }
            else
            {
                result = pValor.Substring(0, (pValor.Length - 2)) + "," + pValor.Substring((pValor.Length - 2), 2);
            }
            

            return result;
        }

        public static bool ValidaNumero(string pNumero)
        {
            bool result = false;
            long x = 0;

            bool b = long.TryParse(pNumero, out x);

            if (b)
            {
                result = true;
            }

            return result;
        }

        public static string StringEmpity(string texto)
        {
            return texto == string.Empty ? "0" : texto;
        }

    }
}
