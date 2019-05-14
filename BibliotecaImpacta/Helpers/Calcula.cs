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


            if (DateTime.Compare(emprestimo.DataDeEntregaDoLivro, emprestimo.DataDevolucao) > 0)
            {

                valorEmprestimo += MultaAtrasoDevolicao(emprestimo.DataDeEntregaDoLivro, emprestimo.DataDevolucao);

            }
            return valorEmprestimo;

        }

        private static decimal MultaAtrasoDevolicao(DateTime DataDeEntregaDoLivro, DateTime dataDevolucao)
        {

            var numeroDias = (DataDeEntregaDoLivro - dataDevolucao).TotalDays;

            int valorPorDia = 2;

            return Convert.ToDecimal(numeroDias * valorPorDia);
        }
    }
}