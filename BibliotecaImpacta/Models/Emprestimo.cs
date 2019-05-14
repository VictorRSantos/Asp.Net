using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotecaImpacta.Models
{
    //regra de negocio
    public class Emprestimo
    {

        public virtual int  Id { get; set; }

        public  virtual Livro Livro { get; set; }

        public virtual Cliente Cliente { get; set; }
        [DisplayName("Data Empréstimo")]
        public virtual DateTime DataEmprestimo { get; set; }

        [DisplayName("Data Devolução")]
        public virtual DateTime DataDevolucao { get; set; }

        [DisplayName("Data de entrega do Livro")]
        public virtual DateTime DataDeEntregaDoLivro { get; set; }

        [Required]
        public virtual int LivroId { get; set; }

        [Required]
        public virtual int ClienteId { get; set; }

        [DisplayName("Valor Pago")]
        public virtual decimal ValorPago { get; set; }

        [DisplayName("Livro devolvido")]       
        [DefaultValue(false)]
        public virtual bool LivroFoiDevolvido { get; set; }

        public void CadastrarEmprestimo (Emprestimo emprestimo)
        {
            Livro.AtualizaQuantidadeLivroEmprestado(emprestimo.LivroId);
            using(BibliotecaDB db = new BibliotecaDB())
            {
                db.Emprestimos.Add(emprestimo);
                db.SaveChanges();
            }
        }


        public  void CadastrarDevolucao(Emprestimo emprestimo)
        {


            emprestimo.ValorPago = Calcula.ValoEmprestimoLivro(emprestimo);

            Livro.AtualizaQuantidadeLivroDevolucao(emprestimo.LivroId);
            emprestimo.LivroFoiDevolvido = true;
            using(BibliotecaDB db = new BibliotecaDB())
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
            }

        }

    }
}