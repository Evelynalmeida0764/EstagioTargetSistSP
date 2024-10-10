using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estagio_são_paulo
{

    public class StringHelper
    {
        public static string InverterString(string original)
        {
            string invertida = "";
            for (int i = original.Length - 1; i >= 0; i--)
                invertida = invertida + original.Substring(i, 1);

            //for (int i = original.Length - 1; i >= 0; i--) // Percorre do final ao início
            //{
            //    invertida += original[i]; // Acessa diretamente o caractere pelo índice
            //}
            return invertida;
        }
    }
}
