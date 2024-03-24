using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Options;
using Paradigmi.Libreria.Application.Services;
using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUtenteService,UtenteService>();
builder.Services.AddScoped<UtenteRepository>();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));
});

var jwtAuthenticationOption = new JwtAuthenticationOption();
builder.Configuration.GetSection("JwtAuthentication")
    .Bind(jwtAuthenticationOption);
builder.Services.Configure<JwtAuthenticationOption>(builder.Configuration.GetSection("JwtAuthentication"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtAuthenticationOption.Issuer,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
