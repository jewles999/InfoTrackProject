using FluentValidation.AspNetCore;
using InfoTrack.Application;
using InfoTrack.Application.Contracts.Infrastructure;
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
            services.AddTransient<ISearchDtoMapper, SearchDtoMapper>();

            services.Configure<GoogleSettings>(
                builder.Configuration.GetSection("GoogleSettings"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("corsapp");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}