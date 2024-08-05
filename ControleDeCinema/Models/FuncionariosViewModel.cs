using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ControleDeCinema.Models
{
    public class ComplexidadeDaSenha : ValidationAttribute
    {
        private readonly int _minLength;

        public ComplexidadeDaSenha(int minLength)
        {
            _minLength = minLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;
            if (password == null || password.Length < _minLength)
            {
                return new ValidationResult($"A senha deve ter pelo menos {_minLength} caracteres.");
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return new ValidationResult("A senha deve conter pelo menos uma letra maiúscula.");
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                return new ValidationResult("A senha deve conter pelo menos uma letra minúscula.");
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                return new ValidationResult("A senha deve conter pelo menos um número.");
            }

            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                return new ValidationResult("A senha deve conter pelo menos um caractere especial.");
            }

            return ValidationResult.Success;
        }
    }

    public class CadastrarFuncionariosViewModel
    {
        [Required(ErrorMessage = "É necessário preencher o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário preencher o usuário!")]
        public int Login { get; set; }

        [Required(ErrorMessage = "É necessário preencher a senha!")]
        [ComplexidadeDaSenha(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas e caracteres especiais.")]
        public string Senha { get; set; }

    }

    public class ApagarFuncionariosViewModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class ListarFuncionariosViewModel
    {
        public string login { get; set; }
    }

    public class DetalhesFuncionariosViewModel
    {
        public int Nome { get; set; }
        public int login { get; set; }
    }
}
