namespace ControleDeCinema.Dominio.Extensions
{
    public static class Int32Extensions
    {
        public static string FormatarEmHorasEMinutos(this int minutosTotal)
        {
            int horas = minutosTotal / 60;
            int minutos = minutosTotal % 60;

            return $"{horas}h {minutos}m";
        }
    }
}
