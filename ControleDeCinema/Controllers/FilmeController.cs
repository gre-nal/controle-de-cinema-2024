using ControleDeCinema.Dominio.Extensions;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.WebApp.Extensions;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeCinema.WebApp.Controllers
{
    public class FilmeController : Controller
    {
        readonly private IRepositorioFilme repositorioFilme;
        readonly private IRepositorioGenero repositorioGenero;

        public FilmeController(IRepositorioFilme repositorioFilme, IRepositorioGenero repositorioGenero)
        {
            this.repositorioFilme = repositorioFilme;
            this.repositorioGenero = repositorioGenero;
        }

        public IActionResult Listar()
        {
            List<Filme> filmes = repositorioFilme.SelecionarTodos();

            IEnumerable<ListarFilmeViewModel> listarFilmesVm = filmes
                .Select(f => new ListarFilmeViewModel
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Duracao = f.Duracao.FormatarEmHorasEMinutos(),
                    Lancamento = f.Lancamento ? "Lançamento" : "Re-Exibição",
                    Genero = f.Genero.Descricao
                });

            ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

            return View(listarFilmesVm);
        }

        public IActionResult Inserir()
        {
            List<Genero> generosDeFilme = repositorioGenero.SelecionarTodos();

            InserirFilmeViewModel inserirFilmeVm = new InserirFilmeViewModel
            {
                Generos = generosDeFilme
                    .Select(g => new SelectListItem(g.Descricao, g.Id.ToString()))
            };

            return View(inserirFilmeVm);
        }

        [HttpPost]
        public IActionResult Inserir(InserirFilmeViewModel inserirFilmeVm)
        {
            if (!ModelState.IsValid)
            {
                List<Genero> generosDeFilme = repositorioGenero.SelecionarTodos();

                inserirFilmeVm.Generos = generosDeFilme
                    .Select(g => new SelectListItem(g.Descricao, g.Id.ToString()));

                return View(inserirFilmeVm);
            }

            Genero ? generoSelecionado =
                repositorioGenero.SelecionarPorId(inserirFilmeVm.GeneroId.GetValueOrDefault());

            Filme filme = new Filme
            {
                Titulo = inserirFilmeVm.Titulo,
                Lancamento = inserirFilmeVm.Lancamento,
                Duracao = inserirFilmeVm.Duracao,
                Genero = generoSelecionado
            };

            repositorioFilme.Inserir(filme);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{filme.Id}] foi inserido com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Editar(int id)
        {
            Filme ? filme = repositorioFilme.SelecionarPorId(id);

            if (filme is null)
                return MensagemRegistroNaoEncontrado(id);

            List<Genero> generosDeFilme = repositorioGenero.SelecionarTodos();

            EditarFilmeViewModel editarFilmeVm = new EditarFilmeViewModel
            {
                Id = id,
                Titulo = filme.Titulo,
                Duracao = filme.Duracao,
                Lancamento = filme.Lancamento,
                Generos = generosDeFilme
                    .Select(g => new SelectListItem(g.Descricao, g.Id.ToString())),
                GeneroId = filme.Genero.Id
            };

            return View(editarFilmeVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarFilmeViewModel editarFilmeVm)
        {
            if (!ModelState.IsValid)
            {
                List<Genero> generosDeFilme = repositorioGenero.SelecionarTodos();

                editarFilmeVm.Generos = generosDeFilme
                    .Select(g => new SelectListItem(g.Descricao, g.Id.ToString()));

                return View(editarFilmeVm);
            }

            Genero ? generoSelecionado =
                repositorioGenero.SelecionarPorId(editarFilmeVm.GeneroId);

            Filme ? filme = repositorioFilme.SelecionarPorId(editarFilmeVm.Id);

            filme!.Titulo = editarFilmeVm.Titulo;
            filme!.Duracao = editarFilmeVm.Duracao;
            filme!.Lancamento = editarFilmeVm.Lancamento;
            filme!.Genero = generoSelecionado;

            repositorioFilme.Editar(filme);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{filme.Id}] foi editado com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Excluir(int id)
        {
            Filme ? filme = repositorioFilme.SelecionarPorId(id);

            if (filme is null)
                return MensagemRegistroNaoEncontrado(id);

            DetalhesFilmeViewModel detalhesFilmeViewModel = new DetalhesFilmeViewModel
            {
                Id = id,
                Titulo = filme.Titulo,
                Duracao = filme.Duracao.FormatarEmHorasEMinutos(),
                Lancamento = filme.Lancamento ? "Lançamento" : "Re-Exibição",
                Genero = filme.Genero.Descricao
            };

            return View(detalhesFilmeViewModel);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesFilmeViewModel detalhesFilmeViewModel)
        {
            Filme ? filme = repositorioFilme.SelecionarPorId(detalhesFilmeViewModel.Id);

            if (filme is null)
                return MensagemRegistroNaoEncontrado(detalhesFilmeViewModel.Id);

            repositorioFilme.Excluir(filme);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{filme.Id}] foi excluído com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Detalhes(int id)
        {
            Filme ? filme = repositorioFilme.SelecionarPorId(id);

            if (filme is null)
                return MensagemRegistroNaoEncontrado(id);

            DetalhesFilmeViewModel detalhesFilmeViewModel = new DetalhesFilmeViewModel
            {
                Id = id,
                Titulo = filme.Titulo,
                Duracao = filme.Duracao.FormatarEmHorasEMinutos(),
                Lancamento = filme.Lancamento ? "Lançamento" : "Re-Exibição",
                Genero = filme.Genero.Descricao
            };

            return View(detalhesFilmeViewModel);
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
