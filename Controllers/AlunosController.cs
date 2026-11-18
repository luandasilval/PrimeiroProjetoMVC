
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjetoMvc.Models;


namespace PrimeiroProjetoMvc.Controllers
{

    public class AlunosController : Controller
    {
        private static List<Aluno> _alunos = new()
        {
        new Aluno{Id = 1, Nome = "Daniel Vorcaro", Email = "conato.daniel.vorcaro@gmail.com", Idade = 43},
        new Aluno{ Id = 2, Nome = "Diogo Chelles", Email = "p.diogo@gmail.com", Idade = 18},
        };

        //*GET /Alunos  - listar todos os alunos 
        public IActionResult Index()
        {
            return View(_alunos);
        }

        public IActionResult Detalhes(int id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {

        }
    }
}