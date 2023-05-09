using FluentValidation.AspNetCore;
using InfoTrack.Application;
using InfoTrack.Infrastructure;
using InfoTrack.SearchAPI.Config;
using System.Reflection;

namespace SearchAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services;

            services.AddControllers()
                            .AddFluentValidation(options =>
                            {
                                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                            });
            services.AddApplicationServices();
            services.AddInfrastructureServices();

            services.Configure<GoogleSettings>(
                builder.Configuration.GetSection("GoogleSettings"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}