using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WinglyShop.API.Configurations;
using WinglyShop.Application;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Infrastructure;

namespace WinglyShop.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();

			builder.Configuration.AddConfiguration(configuration);

			builder.Services.AddCors(policy =>
			{
				policy.AddPolicy("AllowSpecificOrigin", builder =>
				 builder.WithOrigins("http://localhost:7283/")
				  .SetIsOriginAllowed((host) => true) // Para endereço localhost
				  .AllowAnyMethod()
				  .AllowAnyHeader()
				  .AllowCredentials());
			});

			builder.Services
				.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "WinglyShop.API", Version = "v1" }));

			builder.Services.AddScoped<IDbConnection, DbConnection>(); // Database
			builder.Services.AddScoped<IDispatcher, Dispatcher>(); // Dispatcher
			builder.Services.AddHandlersFromAssembly(typeof(AssemblyReference).Assembly); // Scan the Handlers

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("AllowSpecificOrigin");

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
