﻿using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.Controllers
{
    public class FuncionariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Apagar_Confirmacao()
        {
            return View();
        }
        
        public IActionResult Apagar()
        {
            return View();
        }
        
        public IActionResult Relatorio_Diario()
        {
            return View();
        }

        public IActionResult Relatorio_Sessao()
        {
            return View();
        }
    }
}
