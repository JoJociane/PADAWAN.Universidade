using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PADAWAN.Universidade.Util.Validacoes
{
    public class ValidaMateria : ValidaAll
    {
        public static bool ValidaD(DateTime DataMateria)
        {
            var datahoje = DateTime.Now;
            return DataMateria <= datahoje;
        }

    }
}
