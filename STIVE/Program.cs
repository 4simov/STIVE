using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Core.UseCase.Famille;
using STIVE.Infrastructure;
using STIVE.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<NegosudContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("LocalConnection");
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
    //var connectionString = builder.Configuration.GetConnectionString("LocalMariaDbConnection");
    //var serverVersion = new MariaDbServerVersion(new Version(10, 10, 2));

    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddUseCases();

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
