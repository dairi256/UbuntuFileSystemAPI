
using Microsoft.EntityFrameworkCore;
using UbuntuFileSystemAPI.Data;

namespace UbuntuFileSystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddScoped<Services.IFileService, Services.LocalFileService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=cloudstorage.db"));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
