using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PADAWAN.Universidade.Util.Validacoes
{
    public class ValidaAll
    {
        public static bool ValidaNome(string nome)
        {
            Regex rx = new Regex(@"^[ a-zA-Z á]*$");
            return rx.IsMatch(nome);
        }
    }
}
