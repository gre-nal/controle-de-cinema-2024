using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Filmes;
using ControleDeCinema.Infra.Generos;
using ControleDeCinema.Infra.Salas;
using ControleDeCinema.Infra.Sessoes;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Compartilhado
{
    public class ControleCinemaDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorGeneroEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorFilmeEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorSalaEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorSessaoEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorIngressoEmOrm());

            base.OnModelCreating(modelBuilder);
        }
    }
}
