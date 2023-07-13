using StudentGrades.Application;
using StudentGrades.Infrastructure;

namespace StudentGrades.API
{
    public class Program
    {
        private static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationService();
            builder.Services.AddInfrastructureService(builder.Configuration);


            var app = builder.Build();
            app.UseRateLimiter();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.DisplayRequestDuration());
            }

            app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}