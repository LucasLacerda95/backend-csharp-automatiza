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
                .UseMySql(configuration.GetConnectionString("AutomatizaConnection"), serverVersion));


            return services;
        }

    }

}
