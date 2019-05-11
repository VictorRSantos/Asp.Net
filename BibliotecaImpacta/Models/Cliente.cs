using BibliotecaImpacta.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaImpacta.Models
{
    public class Cliente
    {

        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        [Required]
        [ValidacaoCPF]
        public virtual string Cpf { get; set; }

        [Required]
        public virtual string Email { get; set; }
    }
}