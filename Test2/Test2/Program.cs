using Microsoft.EntityFrameworkCore;
using Test2.DAL.Model.Db;
using Test2.Services;

namespace Test2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        //adding controllers
        builder.Services.AddControllers();

        //to use DI
        builder.Services.AddScoped<IDbService, DbService>();
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
        });
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}