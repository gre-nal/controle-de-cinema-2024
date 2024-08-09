using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Generos
{
    public class RepositorioGeneroEmOrm : RepositorioBaseEmOrm<Genero>, IRepositorioGenero
    {
        public RepositorioGeneroEmOrm
        (
            ControleCinemaDbContext dbContext
        ) : base(dbContext)
        {
        }

        protected override DbSet<Genero> ObterRegistros()
        {
            return _dbContext.Generos;
        }
    }
}
