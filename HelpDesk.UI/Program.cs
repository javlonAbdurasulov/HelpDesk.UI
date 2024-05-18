using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain.Models;
using HelpDesk.Infrastructure.Data;
using HelpDesk.Infrastructure.Service;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

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

            #region RateLimiter
            MyRateLimitOptions myOptions = new MyRateLimitOptions();
            builder.Configuration.GetSection(MyRateLimitOptions.MyRateLimit).Bind(myOptions);
            builder.Services.AddRateLimiter(
                rateLimiterOptions =>
                {
                    rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                    rateLimiterOptions.AddFixedWindowLimiter("fixed",
                    opt =>
                    {
                        opt.Window = TimeSpan.FromSeconds(12);
                        opt.PermitLimit = 3;
                        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                        opt.QueueLimit = 0;
                        opt.AutoReplenishment = true;


                    });
                    #region MyRegion

                    //rateLimiterOptions.AddTokenBucketLimiter("token", opt =>
                    //{
                    //    opt.TokenLimit = 100;
                    //    opt.ReplenishmentPeriod = TimeSpan.FromSeconds(2);
                    //    opt.TokensPerPeriod = 10;
                    //});

                    //rateLimiterOptions.AddSlidingWindowLimiter("sliding", opt =>
                    //{
                    //    opt.Window = TimeSpan.FromSeconds(15);
                    //    opt.SegmentsPerWindow = 3;
                    //    opt.PermitLimit = 15;
                    //});

                    //rateLimiterOptions.AddConcurrencyLimiter("concurency", opt =>
                    //{
                    //    opt.PermitLimit = 5;
                    //});
                    #endregion

                    rateLimiterOptions.AddTokenBucketLimiter("token", opt =>
                    {
                        opt.TokenLimit = myOptions.TokenLimit;
                        opt.ReplenishmentPeriod = TimeSpan.FromSeconds(myOptions.ReplenishmentPeriod);
                        opt.TokensPerPeriod = myOptions.TokensPerPeriod;
                    });
                }
            );
            #endregion

            #region Db

            builder.Services.AddDbContext<AppDbContext>(option => 
			option.UseNpgsql(builder.Configuration.GetConnectionString("JavlonDb")));
			
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
			app.UseRouting();

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
