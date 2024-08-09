using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloSala
{
    public class Sala : EntidadeBase
    {

        public Sala() {}

        public Sala(int numero, int capacidade)
        {
            Numero = numero;
            Capacidade = capacidade;
        }

        public int Numero { get; set; }
        public int Capacidade { get; set; }
    }
}
