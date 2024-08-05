using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.Models
{
    public class CadastrarClientesViewModel
    {
        [Required(ErrorMessage = "É necessário preencher o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário preencher o CPF!")]
        [Range(11,11, ErrorMessage = "É necessário que o CPF contenha 11 números")]
        public int CPF { get; set; }
    }

    public class ApagarClientesViewModel
    {
        public int Nome { get; set; }
        public int CPF { get; set; }
    }

    public class ListarClientesViewModel
    {
        public int Nome { get; set; }
    }

    public class DetalhesClientesViewModel
    {
        public int Nome { get; set; }
        public int CPF { get; set; }
    }
}
