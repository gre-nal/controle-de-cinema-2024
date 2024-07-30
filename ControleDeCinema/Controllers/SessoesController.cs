using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.Controllers
{
    public class SessoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
