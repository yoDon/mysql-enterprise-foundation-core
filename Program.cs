using Microsoft.EntityFrameworkCore;
using SampleMySqlEfCore;

//
// NOTE: To create the database and tables, run the following commands before running this project:
//
//     dotnet tool install --global dotnet-ef
//     rm -r ./Migrations
//     dotnet ef migrations add Initial -o Migrations -c SampleDbContext
//     dotnet ef database update -c SampleDbContext
//

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleDbContext>(options =>
    {
        //
        // NOTE: There are two MySql adapters for EntityFramework,
        //       one from MySql, the other from the Pomelo Foundation.
        //       They both have UseMySql() functions but they capitalize
        //       them differently - UseMySql() vs UseMySQL()
        //
        options.UseMySql(
          builder.Configuration.GetConnectionString("DefaultConnection"),
          new MySqlServerVersion(new Version()));
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
