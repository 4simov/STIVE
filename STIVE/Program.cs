using Microsoft.EntityFrameworkCore;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Core.UseCase.Famille;
using STIVE.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Services.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<NegosudContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("RemoteConnection");
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
    //var connectionString = builder.Configuration.GetConnectionString("LocalMariaDbConnection");
    //var serverVersion = new MariaDbServerVersion(new Version(10, 10, 2));

    options.UseMySql(connectionString, serverVersion);
});
//Rajouté pour les droits 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//Partie concernant la gestion des droits de consommation de l'API
builder.Services.AddAuthentication( options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer =true,
            ValidateAudience =false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey =true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("1"));
    options.AddPolicy("Client", policy => policy.RequireRole("2"));
});

builder.Services.AddControllers();
builder.Services.AddUseCases();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
