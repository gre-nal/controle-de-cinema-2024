using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloGenero
{
    public class Genero : EntidadeBase
    {

        public Genero() {}

        public Genero(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }
    }
}
