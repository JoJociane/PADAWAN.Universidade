using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PADAWAN.Universidade.Util.Validacoes
{
    public class ValidaAluno : ValidaAll
    {
        public static bool ValidaCpf(string cpf)
        {
            Regex rx = new Regex(@"^([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})$");
            return (rx.IsMatch(cpf));
        }

        public static bool ValidaData(DateTime? DataNascimento)
        {
            Regex rx = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$");
            var datalimite = new DateTime(2002, 01, 01);
            return DataNascimento <= datalimite;
        }

        public static bool ValidaD(DateTime DataMateria)
        {
            var datahoje = DateTime.Now;
            return DataMateria <= datahoje;
        }

    }
}
