using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaImpacta.Helpers
{
    public static class Calcula
    {

        public static decimal ValoEmprestimoLivro(Emprestimo emprestimo)
        {
            decimal valorEmprestimo = 1m;


            if (DateTime.Compare(emprestimo.DataDevolucao, emprestimo.DataEmprestimo) > 0)
            {

                valorEmprestimo += MultaAtrasoDevolicao(emprestimo.DataEmprestimo, emprestimo.DataDevolucao);

            }
            return valorEmprestimo;

        }

        private static decimal MultaAtrasoDevolicao(DateTime dataEmprestimo, DateTime dataDevolucao)
        {

            var numeroDias = (dataDevolucao - dataEmprestimo).TotalDays;

            int valorPorDia = 2;

            return Convert.ToDecimal(numeroDias * valorPorDia);
        }
    }
}