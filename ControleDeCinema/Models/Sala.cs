namespace ControleDeCinema.Models
{
    public class Sala(int IdSala, int Numero, int Capacidade, int NumeroDeAssentos)
    {
        public int IdSala { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public int NumeroDeAssentos { get; set; }
    }
}
