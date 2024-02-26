using crud.API.Configuration;

namespace crud.API
{
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddEntityConfiguration(builder.Configuration); //Configuration/EntityConfig

            builder.Services.ResolveDependencias();  //Configuration/DependencyInjectionConfig

            builder.Services.AddWebApiConfig(); //Configuration/ApiConfig

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//Configuration/AutoMapperConf
            


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseAuthentication();//Adiciona Middlewere de autenticação, encapsula o acesso à API

            app.UseWebApiConfig();


            app.Run();
        }
    }
}
