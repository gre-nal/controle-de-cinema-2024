using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Filmes
{
    public class RepositorioFilmeEmOrm : RepositorioBaseEmOrm<Filme>, IRepositorioFilme
    {
        public RepositorioFilmeEmOrm
        (
            ControleCinemaDbContext dbContext
        ) : base(dbContext)
        {
        }

        public override Filme ? SelecionarPorId(int id)
        {
            return ObterRegistros().Include(f => f.Genero)
                .FirstOrDefault(f => f.Id == id);
        }

        public override List<Filme> SelecionarTodos()
        {
            return ObterRegistros().Include(f => f.Genero)
                .ToList();
        }

        protected override DbSet<Filme> ObterRegistros()
        {
            return _dbContext.Filmes;
        }
    }
}
