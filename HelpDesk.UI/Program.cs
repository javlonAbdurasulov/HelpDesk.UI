using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Infrastructure.Data;
using HelpDesk.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			#region Db

			builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("ShokirsDb")));
			
			#endregion

			#region Scoped

			builder.Services.AddScoped<IFormService, FormService>();
			builder.Services.AddScoped<ILetterService,LetterService>();

			#endregion


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
