using ControleDeCinema.Dominio.ModuloSala;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeCinema.Infra.Salas
{
    public class MapeadorSalaEmOrm : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> sBuilder)
        {
            sBuilder.ToTable("TBSala");

            sBuilder.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            sBuilder.Property(s => s.Numero)
                .IsRequired()
                .HasColumnType("int");

            sBuilder.Property(s => s.Capacidade)
                .IsRequired()
                .HasColumnType("int");

            sBuilder.HasData(ObterRegistrosPadrao());
        }

        private object[] ObterRegistrosPadrao()
        {
            return
            [
                new { Id = 1, Numero = 1, Capacidade = 30 },
                new { Id = 2, Numero = 2, Capacidade = 35 },
                new { Id = 3, Numero = 5, Capacidade = 32 }
            ];
        }
    }
}
