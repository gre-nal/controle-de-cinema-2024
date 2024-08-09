using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Salas
{
    public class RepositorioSalaEmOrm : RepositorioBaseEmOrm<Sala>, IRepositorioSala
    {
        public RepositorioSalaEmOrm
        (
            ControleCinemaDbContext dbContext
        ) : base(dbContext)
        {
        }

        protected override DbSet<Sala> ObterRegistros()
        {
            return _dbContext.Salas;
        }
    }
}
