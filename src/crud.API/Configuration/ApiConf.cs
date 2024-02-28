using crud.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace crud.API.Configuration
{
    public static class ApiConf
    {

        public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
        {

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddHttpClient("API", options =>
            {
                options.BaseAddress = new Uri("https://catalogoautomatiza.azurewebsites.net/api/");
            });//cria endPoint e HTTP client para consumir api

            services.AddScoped<HttpClient>();//Determina o tempo de vida do pacote e chama quando precisa 

            return services;
        }


        public static IApplicationBuilder UseWebApiConfig(this WebApplication app)
        {

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }


        public static IServiceCollection AddEntityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 6, 15));

            services.AddDbContext<DataContext>
            (options => options
                .UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion));


            return services;
        }

    }

}
