
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjetoMvc.Models;
using PrimeiroProjetoMvc.ViewModels;


namespace PrimeiroProjetoMvc.Controllers
{

    public class AlunosController : Controller
    {
        private static List<Aluno> _alunos = new()
        {
        new Aluno{Id = 1, Nome = "Daniel Vorcaro", Email = "conato.daniel.vorcaro@gmail.com", Idade = 43},
        new Aluno{ Id = 2, Nome = "Diogo Chelles", Email = "p.diogo@gmail.com", Idade = 18},
        };

        //GET /Alunos  - listar todos os alunos 
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

        // GET  /Alunos/Criar - exibir a view com todos os alunos 
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        // POST Alunos/Criar - receber dados da view por meio de um formulario de cadastro para adicionar um novo aluno 
        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {
            if (!ModelState.IsValid) //verifica se as validações atribuidas na model foram atendidas
            {
                return View(aluno); //retorna com erros de validação
            }

            aluno.Id = _alunos.Any() ? _alunos.Max(a => a.Id) + 1 : 1;

            _alunos.Add(aluno);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaAlunoViewModel());
        }

        [HttpPost]
        public IActionResult Buscar(BuscaAlunoViewModel vm)
        {
            vm.Resultados = _alunos; //Carrega a lista de alunos na propriedade resultados do objeto vm

            if (!string.IsNullOrEmpty(vm.TermoBusca))
            {
                //se termo busca não for vazio, pesquise o termo na lista de resultados
                vm.Resultados = _alunos.Where(a => a.Nome.Contains(vm.TermoBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(vm);
        }
    }
}