using System.Runtime.CompilerServices;
using crud.BLL.Interfaces;
using crud.BLL.Models;
using crud.BLL.Services;
using crud.DAL.Context;
using crud.DAL.Repository;



namespace crud.API.Configuration
{
    public static class InjecaoDeDependenciaConf
    {
        //Método de extensao do IServiceCollection
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {

            services.AddScoped<DataContext>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();


            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
