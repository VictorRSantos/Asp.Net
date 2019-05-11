using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public virtual DateTime DataEmprestimo { get; set; }

        public virtual DateTime DataDevolucao { get; set; }

        [Required]
        public virtual int LivroId { get; set; }


    }
}