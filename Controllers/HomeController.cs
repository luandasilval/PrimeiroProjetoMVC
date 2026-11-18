using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjetoMvc.Models;

namespace PrimeiroProjetoMvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        //*a view index le essa chave para exibir a mensagem
        ViewData["Mensagem"] = "Bem-vindo ao sistema!";
        return View();
    }
    //*Action que recebe parametro pela: /Home/Sobre/5
    public IActionResult Sobre(int? id)
    {
        ViewBag.Versao = "1.0";
        ViewBag.ParametroId = id;
        return View();
    }
    //*Action que recebe parametros via query string : /Home/Saudacao?nome=Kessia
    public IActionResult Saudacao(string nome)
    {
        //Model inding obtem nome da url; usa "visitante" se nada for informado
        ViewData["Nome"] = nome ?? "Visitante";
        //?? default
        return View();
    }
}
