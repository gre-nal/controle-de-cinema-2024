using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.Models
{
    public class CadastrarSalasViewModel
    {
        [Required(ErrorMessage = "É necessário preencher um número uma sala!")]
        [Range(1, int.MaxValue, ErrorMessage = "É necessário que a sala seja um número válido!")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "É necessário preencher a capacidade!")]
        [Range(1, int.MaxValue, ErrorMessage = "É necessário que a capacidade tenha um número válido!")]
        public int Capacidade { get; set; }
    }

    public class ApagarSalasViewModel
    {
        public int Numero { get; set; }
        public int Capacidade { get; set; }
    }

    public class ListarSalasViewModel
    {
        public int Numero { get; set; }
    }

    public class DetalhesSalasViewModel
    {
        public int Numero { get; set; }
        public int Capacidade { get; set; }
    }
}
