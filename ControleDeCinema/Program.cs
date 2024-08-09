using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Compartilhado;
using ControleDeCinema.Infra.Filmes;
using ControleDeCinema.Infra.Generos;
using ControleDeCinema.Infra.Salas;
using ControleDeCinema.Infra.Sessoes;

namespace ControleDeCinema.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            #region Injeção de Dependência de Serviços
            builder.Services.AddDbContext<ControleCinemaDbContext>();

            builder.Services.AddScoped<IRepositorioGenero, RepositorioGeneroEmOrm>();
            builder.Services.AddScoped<IRepositorioFilme, RepositorioFilmeEmOrm>();
            builder.Services.AddScoped<IRepositorioSala, RepositorioSalaEmOrm>();
            builder.Services.AddScoped<IRepositorioSessao, RepositorioSessaoEmOrm>();
            #endregion

            WebApplication app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute("default", "{controller=Inicio}/{action=Index}/{id:int?}");

            app.Run();
        }
    }
}
