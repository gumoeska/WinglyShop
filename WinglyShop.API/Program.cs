using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Transactions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Configurations;
using WinglyShop.API.Services.Auth;
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

			//builder.Services.Configure<SecretKey>(configuration.GetSection("SecretKey")); // Configuring the secret key

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();

			builder.Services.AddHttpContextAccessor();

			builder.Configuration.AddConfiguration(configuration);

			builder.Services.AddCors(policy =>
			{
				policy.AddPolicy("AllowSpecificOrigin", builder =>
				 builder.WithOrigins("http://localhost:7283/")
				  .SetIsOriginAllowed((host) => true) // localhost
				  .AllowAnyMethod()
				  .AllowAnyHeader()
				  .AllowCredentials());
			});

			builder.Services
				.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "WinglyShop.API", Version = "v1" }));

			// EF Core
			builder.Services.AddDbContext<DatabaseContext>(options =>
			{
				var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

				options.UseSqlServer(connectionString, sqlServerAction =>
				{
					sqlServerAction.EnableRetryOnFailure(3);
					sqlServerAction.CommandTimeout(30);
				});

				options.EnableDetailedErrors(true);
				options.EnableSensitiveDataLogging(true);
			});

			builder.Services.AddScoped<IDatabaseContext, DatabaseContext>(); // Database

			// Dapper
			builder.Services.AddScoped<IDbConnection, DbConnection>(); // Database

			builder.Services.AddScoped<IDispatcher, Dispatcher>(); // Dispatcher
			builder.Services.AddScoped<ITokenService, TokenService>(); // Token Service
			builder.Services.AddHandlersFromAssembly(typeof(AssemblyReference).Assembly); // Scan the Handlers

			// Authentication
			var secretKey = Encoding.ASCII.GetBytes(SecretKey.Key);

			builder.Services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(secretKey),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

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
