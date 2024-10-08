﻿using ControleDeCinema.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Compartilhado
{
    public abstract class RepositorioBaseEmOrm<TEntidade> where TEntidade : EntidadeBase
    {
        protected readonly ControleCinemaDbContext _dbContext;

        protected RepositorioBaseEmOrm(ControleCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected abstract DbSet<TEntidade> ObterRegistros();

        public void Inserir(TEntidade entidade)
        {
            ObterRegistros().Add(entidade);

            _dbContext.SaveChanges();
        }

        public void Editar(TEntidade entidade)
        {
            ObterRegistros().Update(entidade);

            _dbContext.SaveChanges();
        }

        public void Excluir(TEntidade entidade)
        {
            ObterRegistros().Remove(entidade);

            _dbContext.SaveChanges();
        }

        public virtual TEntidade ? SelecionarPorId(int id)
        {
            return ObterRegistros().FirstOrDefault(r => r.Id == id);
        }

        public virtual List<TEntidade> SelecionarTodos()
        {
            return ObterRegistros()
                .ToList();
        }
    }
}
