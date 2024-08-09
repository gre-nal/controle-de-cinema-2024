using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloSessao
{
    public class Ingresso : EntidadeBase
    {

        public Ingresso() {}

        public Ingresso(int numeroAssento, bool meiaEntrada)
        {
            NumeroAssento = numeroAssento;
            MeiaEntrada = meiaEntrada;
        }

        public bool MeiaEntrada { get; set; }
        public int NumeroAssento { get; set; }

        public Sessao Sessao { get; set; }
    }
}
