﻿using ControleDeCinema.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeCinema.Infra.Funcionarios
{
    public class MapeadorFuncionarioEmOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> fBuilder)
        {
            fBuilder.ToTable("TBFuncionario");

            fBuilder.Property(f => f.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            fBuilder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            fBuilder.Property(f => f.Login)
                .IsRequired()
                .HasColumnType("varchar(100)");

            fBuilder.Property(f => f.Senha)
                .IsRequired()
                .HasColumnType("varchar(64)");

            fBuilder.HasData(ObterRegistrosPadrao());
        }

        private object[] ObterRegistrosPadrao()
        {
            return
            [
                new
                {
                    Id = 1,
                    Nome = "Caio Tanaka",
                    Login = "c.tanaka",
                    Senha = "sFQZT5W2kK8BUAO8uhhQ"
                },
                new
                {
                    Id = 2,
                    Nome = "Júnior Teixeira",
                    Login = "junior.teixeira201",
                    Senha = "eNsoNQxmzglCOs3OK76a"
                },
                new
                {
                    Id = 3,
                    Nome = "Márcia Silva",
                    Login = "marcia.silva0306",
                    Senha = "AW6m9OHzgB28v4ZNS5jY"
                }
            ];
        }
    }
}
