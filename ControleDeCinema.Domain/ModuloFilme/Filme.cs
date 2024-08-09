using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.Dominio.ModuloSessao;

namespace ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme : EntidadeBase
    {

        public Filme()
        {
            Sessoes = new List<Sessao>();
        }

        public Filme(string titulo, int duracao, Genero genero, bool lancamento) : this()
        {
            Titulo = titulo;
            Duracao = duracao;
            Genero = genero;
            Lancamento = lancamento;
        }

        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public Genero Genero { get; set; }
        public bool Lancamento { get; set; }
        public List<Sessao> Sessoes { get; set; }
    }
}
