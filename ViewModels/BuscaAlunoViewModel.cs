using PrimeiroProjetoMvc.Models;

namespace PrimeiroProjetoMvc.ViewModels
{
    public class BuscaAlunoViewModel
    {
        public string? TermoBusca { get; set; }

        public List<Aluno> Resultados { get; set; } = new();
        
    }
}