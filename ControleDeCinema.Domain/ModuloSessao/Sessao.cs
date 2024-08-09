﻿using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;

namespace ControleDeCinema.Dominio.ModuloSessao
{
    public class Sessao : EntidadeBase
    {

        private bool _encerrada;

        public Sessao()
        {
            Ingressos = new List<Ingresso>();
        }

        public Sessao(Filme filme, Sala sala, int numeroMaximoIngressos, DateTime inicio) : this()
        {
            Filme = filme;
            Sala = sala;
            NumeroMaximoIngressos = numeroMaximoIngressos;
            Inicio = inicio;
        }

        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public bool Encerrada
        {
            get => _encerrada ||
                Inicio.AddMinutes(Filme.Duracao) < DateTime.Now;
            set => _encerrada = value;
        }

        public int NumeroMaximoIngressos { get; set; }
        public DateTime Inicio { get; set; }
        public List<Ingresso> Ingressos { get; set; }

        public int[] ObterAssentosDisponiveis()
        {
            IEnumerable<int> assentosDisponiveis = Enumerable.Range(1, NumeroMaximoIngressos);

            int[] assentosOcupados = Ingressos.Select(i => i.NumeroAssento).ToArray();

            return assentosDisponiveis
                .Except(assentosOcupados)
                .ToArray();
        }

        public int ObterQuantidadeIngressosDisponiveis()
        {
            return NumeroMaximoIngressos - Ingressos.Count;
        }

        public Ingresso GerarIngresso(int assentoSelecionado, bool meiaEntrada)
        {
            Ingresso ingresso = new Ingresso(assentoSelecionado, meiaEntrada);

            Ingressos.Add(ingresso);

            return ingresso;
        }

        public void Encerrar()
        {
            Encerrada = true;
        }
    }
}
