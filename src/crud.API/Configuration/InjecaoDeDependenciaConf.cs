using System.Runtime.CompilerServices;
using crud.BLL.Interfaces;
using crud.BLL.Models;
using crud.DAL.Context;


namespace crud.API.Configuration
{
    public static class InjecaoDeDependenciaConf
    {
        //Método de extensao do IServiceCollection
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {

            services.AddScoped<DataContext>();
            //services.AddScoped<IMarcaRepository, MarcaRepository>();


            return services;
        }
    }
}
