using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Funcionarios
{
    public class RepositorioFuncionarioEmOrm : RepositorioBaseEmOrm<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioEmOrm
        (
            ControleCinemaDbContext dbContext
        ) : base(dbContext)
        {
        }

        protected override DbSet<Funcionario> ObterRegistros()
        {
            return _dbContext.Funcionarios;
        }
    }
}
