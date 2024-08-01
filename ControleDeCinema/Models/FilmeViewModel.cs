using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.Models
{
    public class CadastrarFilmeViewModel
    {
        [Required(ErrorMessage = "É necessário preencher o título!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "É necessário selecionar um gênero!")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "É necessário preencher com a duracao!")]
        public TimeOnly Duracao { get; set; }

        [Required(ErrorMessage = "É necessário preencher a descrição!")]
        public string Descricao { get; set; }
    }

    public class ApagarFilmeViewModel
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public TimeOnly Duracao { get; set; }
        public string Descricao { get; set; }
    }

    public class ListarFilmeViewModel
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public TimeOnly Duracao { get; set; }
    }

    public class DetalhesFilmeViewModel
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public TimeOnly Duracao { get; set; }
        public string Descricao { get; set; }
    }
}
