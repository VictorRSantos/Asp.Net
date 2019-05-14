using BibliotecaImpacta.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaImpacta.Models
{
    public class Cliente
    {

        public virtual int Id { get; set; }

       
        [DisplayName("Nome Cliente")]
        public virtual string Nome { get; set; }

        
        [DisplayName("CPF")]
        [ValidacaoCPF(ErrorMessage = "CPF inválido")]
        public virtual string Cpf { get; set; }

        
        [DisplayName("E-mail")]
        public virtual string Email { get; set; }
    }
}