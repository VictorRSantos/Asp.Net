using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaImpacta.Models
{
    public class Livro
    {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [DisplayName("Nome do Livro")]
        public string Nome { get; set; }

        [DisplayName("Total de páginas do Livro")]
        public int TotalDePaginas { get; set; }

        [DisplayName("Descrição do Livro")]
        public string Descricao { get; set; }

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        public Categoria Categoria { get; set; }

        public Autor Autor { get; set; }
        
        public int CategoriaId { get; set; }

        public int AutorId { get; set; }

    }
}