using Microsoft.OpenApi.Models;

namespace Talabat.APIs.Exctenions
{
    public static class SwaggerServicesExtenions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talabat.APIs", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumintaion(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talabat.APIs v1"));


            return app;
        }
    }
}
