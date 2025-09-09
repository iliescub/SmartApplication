
using Microsoft.EntityFrameworkCore;
using SmartAppl.Infrastructure;
using Scalar.AspNetCore;


namespace SmartAppl.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Configurating services - Start
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SmartApplContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"),
                providerOptions => providerOptions.EnableRetryOnFailure());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            #endregion Configurating services - End

            #region Configurating Middleware - Start

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("My API");
                    options.WithTheme(ScalarTheme.Laserwave);
                    options.WithSidebar(true);
                    options.WithLayout(ScalarLayout.Classic);
                });
                app.UseSwaggerUi(options =>
                {
                    options.DocumentPath = "openapi/v1.json";
                }); 
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 

            app.Run();
            #endregion Configurating Middleware - End
        }
    }
}
