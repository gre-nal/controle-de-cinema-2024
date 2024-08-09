using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloSessao
{
    public interface IRepositorioSessao : IRepositorio<Sessao>
    {
        List<IGrouping<string, Sessao>> ObterSessoesAgrupadasPorFilme();
        List<int> ObterNumerosAssentosOcupados(int sessaoId);
        List<IGrouping<string, Sessao>> ObterSessoesDisponiveisAgrupadas();
    }
}
