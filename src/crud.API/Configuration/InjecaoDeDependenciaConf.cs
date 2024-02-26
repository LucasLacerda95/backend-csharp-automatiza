using System.Runtime.CompilerServices;
using crud.DAL.Context;


namespace crud.API.Configuration
{
    public static class InjecaoDeDependenciaConf
    {

        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();

            return services;
        }
    }
}
