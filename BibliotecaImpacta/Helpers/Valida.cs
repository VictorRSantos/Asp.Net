using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace BibliotecaImpacta.Helpers
{
    public class Valida
    {

        private static string RemoveNaoNumerico(string cpf)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string cpfLimpo = reg.Replace(cpf, string.Empty);
            return cpfLimpo;

        }

        public static bool CPF(string cpf)
        {
            cpf = RemoveNaoNumerico(cpf);
            if (cpf.Length > 11)
               return false;
            
            while (cpf.Length!=11)
                  cpf = '0' + cpf;
                  bool igual = true;

            for (int i = 0; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) + numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[0] != 0)
                {
                    return false;
                }

            }
            else if (numeros[9] != 11 - resultado)
                return false;

            return true;


        }
    }
}