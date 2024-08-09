using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.WebApp.Extensions;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
    public class SalaController : Controller
    {
        readonly private IRepositorioSala repositorioSala;

        public SalaController(IRepositorioSala repositorioSala)
        {
            this.repositorioSala = repositorioSala;
        }

        public IActionResult Listar()
        {
            List<Sala> salas = repositorioSala.SelecionarTodos();

            IEnumerable<ListarSalaViewModel> listarSalasVm = salas
                .Select(f => new ListarSalaViewModel
                {
                    Id = f.Id,
                    Numero = f.Numero,
                    Capacidade = f.Capacidade
                });

            ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

            return View(listarSalasVm);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(InserirSalaViewModel inserirSalaVm)
        {
            if (!ModelState.IsValid)
                return View(inserirSalaVm);

            Sala sala = new Sala
            {
                Numero = inserirSalaVm.Numero,
                Capacidade = inserirSalaVm.Capacidade
            };

            repositorioSala.Inserir(sala);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{sala.Id}] foi inserido com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Editar(int id)
        {
            Sala ? sala = repositorioSala.SelecionarPorId(id);

            if (sala is null)
                return MensagemRegistroNaoEncontrado(id);

            EditarSalaViewModel editarSalaVm = new EditarSalaViewModel
            {
                Id = id,
                Numero = sala.Numero,
                Capacidade = sala.Capacidade
            };

            return View(editarSalaVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarSalaViewModel editarSalaVm)
        {
            if (!ModelState.IsValid)
                return View(editarSalaVm);

            Sala ? sala = repositorioSala.SelecionarPorId(editarSalaVm.Id);

            sala!.Numero = editarSalaVm.Numero;
            sala!.Capacidade = editarSalaVm.Capacidade;

            repositorioSala.Editar(sala);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{sala.Id}] foi editado com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Excluir(int id)
        {
            Sala ? sala = repositorioSala.SelecionarPorId(id);

            if (sala is null)
                return MensagemRegistroNaoEncontrado(id);

            DetalhesSalaViewModel detalhesSalaViewModel = new DetalhesSalaViewModel
            {
                Id = id,
                Numero = sala.Numero,
                Capacidade = sala.Capacidade
            };

            return View(detalhesSalaViewModel);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesSalaViewModel detalhesSalaViewModel)
        {
            Sala ? sala = repositorioSala.SelecionarPorId(detalhesSalaViewModel.Id);

            if (sala is null)
                return MensagemRegistroNaoEncontrado(detalhesSalaViewModel.Id);

            repositorioSala.Excluir(sala);

            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = $"O registro ID [{sala.Id}] foi excluído com sucesso!"
            });

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Detalhes(int id)
        {
            Sala ? sala = repositorioSala.SelecionarPorId(id);

            if (sala is null)
                return MensagemRegistroNaoEncontrado(id);

            DetalhesSalaViewModel detalhesSalaViewModel = new DetalhesSalaViewModel
            {
                Id = id,
                Numero = sala.Numero,
                Capacidade = sala.Capacidade
            };

            return View(detalhesSalaViewModel);
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
