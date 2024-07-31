using ControleDeCinema.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ControleDeCinema.Data
{
    public class CinemaContext : DbContext
    {
        public DbSet<Sessao> Sessões { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("SqlServer")!;

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessao>(sessaoBuilder =>
            {
                sessaoBuilder.ToTable("TBSessao");

                sessaoBuilder.Property(s => s.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                sessaoBuilder.Property(s => s.Sala)
                .IsRequired()
                .HasColumnType("varchar(200)");

                sessaoBuilder.Property(s => s.Filme)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                sessaoBuilder.Property(s => s.Horario)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
                sessaoBuilder.Property(s => s.MaxIngressos)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
