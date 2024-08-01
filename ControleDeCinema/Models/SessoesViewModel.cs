using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.Models
{
    public class CadastrarSessaoViewModel
    {
        [Required(ErrorMessage = "É necessário selecionar uma sala!")]
        [Range(1, int.MaxValue, ErrorMessage = "É necessário que a sala seja um número válido!")]
        public int NumeroSala { get; set; }

        [Required(ErrorMessage = "É necessário selecionar um filme!")]
        public string TituloFilme { get; set; }

        [Required(ErrorMessage = "É necessário preencher o horário!")]
        public TimeOnly Horario { get; set; }

        [Required(ErrorMessage = "É necessário preencher a quantidade de ingressos!")]
        public string QuatidadeIngresso { get; set; }

        [Required(ErrorMessage = "É necessário preencher a cadacidade da sala!")]
        public int CapacidadeSala { get; set; }

        public IEnumerable<SelectListItem>? Filmes { get; set; }
        public IEnumerable<SelectListItem>? Salas { get; set; }
    }

    public class ApagarSessaoViewModel
    {
        public string Filme { get; set; }
        public TimeOnly Horario { get; set; }
        public string Descricao { get; set; }
        public string QuatidadeIngresso { get; set; }
    }

    public class ListarSessaoViewModel
    {
        public string TituloFilme { get; set; }

        public TimeOnly Horario { get; set; }
    }

    public class DetalhesSessaoViewModel
    {
        public int NumeroSala { get; set; }

        public string TituloFilme { get; set; }

        public TimeOnly Horario { get; set; }

        public string QuatidadeIngresso { get; set; }

        public int CapacidadeSala { get; set; }
    }
}
