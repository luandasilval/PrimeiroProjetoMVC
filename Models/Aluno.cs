using System.ComponentModel.DataAnnotations;

namespace PrimeiroProjetoMvc.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " O nome é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 50 caracteres")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = " O email é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        //min e max da idade
        [Range(16, 100, ErrorMessage = "Idade deve ser entre 16 e 100")]
        public int Idade { get; set; }

    }
}