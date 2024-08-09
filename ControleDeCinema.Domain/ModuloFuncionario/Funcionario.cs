using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {

        public Funcionario() {}

        public Funcionario(string login, string senha, string nome)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
