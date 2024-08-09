using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.WebApp.Extensions;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
    public class GeneroController : Controller
    {
        readonly private IRepositorioGenero repositorioGenero;

        public GeneroController(IRepositorioGenero repositorioGenero)
        {
            this.repositorioGenero = repositorioGenero;
        }

        public IActionResult Listar()
        {
            List<Genero> generos = repositorioGenero.SelecionarTodos();

            IEnumerable<ListarGeneroViewModel> listarGenerosVm = generos
                .Select(f => new ListarGeneroViewModel
                {
                    Id = f.Id,
                    Descricao = f.Descricao
                });

            ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

            return View(listarGenerosVm);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(InserirGeneroViewModel inserirGeneroVm)
        {
            if (!ModelState.IsValid)
                return View(inserirGeneroVm);

            Genero genero = new Genero
            {
                Descricao = inserirGeneroVm.Descricao
            };

            repositorioGenero.Inserir(genero);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{genero.Id}] foi inserido com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Editar(int id)
        {
            Genero ? funcionario = repositorioGenero.SelecionarPorId(id);

            if (funcionario is null)
                return MensagemRegistroNaoEncontrado(id);

            EditarGeneroViewModel editarGeneroVm = new EditarGeneroViewModel
            {
                Id = id,
                Descricao = funcionario.Descricao
            };

            return View(editarGeneroVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarGeneroViewModel editarGeneroVm)
        {
            if (!ModelState.IsValid)
                return View(editarGeneroVm);

            Genero ? genero = repositorioGenero.SelecionarPorId(editarGeneroVm.Id);

            genero!.Descricao = editarGeneroVm.Descricao;

            repositorioGenero.Editar(genero);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{genero.Id}] foi editado com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Excluir(int id)
        {
            Genero ? genero = repositorioGenero.SelecionarPorId(id);

            if (genero is null)
                return MensagemRegistroNaoEncontrado(id);

            DetalhesGeneroViewModel detalhesGeneroViewModel = new DetalhesGeneroViewModel
            {
                Id = id,
                Descricao = genero.Descricao
            };

            return View(detalhesGeneroViewModel);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesGeneroViewModel detalhesGeneroViewModel)
        {
            Genero ? genero = repositorioGenero.SelecionarPorId(detalhesGeneroViewModel.Id);

            if (genero is null)
                return MensagemRegistroNaoEncontrado(detalhesGeneroViewModel.Id);

            repositorioGenero.Excluir(genero);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{genero.Id}] foi exclúido com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Detalhes(int id)
        {
            Genero ? genero = repositorioGenero.SelecionarPorId(id);

            if (genero is null)
                return MensagemRegistroNaoEncontrado(id);

            DetalhesGeneroViewModel detalhesGeneroViewModel = new DetalhesGeneroViewModel
            {
                Id = id,
                Descricao = genero.Descricao
            };

            return View(detalhesGeneroViewModel);
        }

        private IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Erro",
                Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
            });

            return RedirectToAction(nameof ( Listar ));
        }
    }
}
