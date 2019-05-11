using System.ComponentModel.DataAnnotations;

namespace BibliotecaImpacta.Models
{
    public class Autor
    {
        
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

    }
}