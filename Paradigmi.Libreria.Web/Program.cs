using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Options;
using Paradigmi.Libreria.Application.Services;
using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Repositories;
using System.Text;
using FluentValidation.AspNetCore;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using Microsoft.OpenApi.Models;
using Paradigmi.Libreria.Web.Results;
using System.Text.Json.Serialization;
using Paradigmi.Libreria.Web.Extensions;
using Paradigmi.Libreria.Application.Token;
using Paradigmi.Libreria.Models.Extensions;
using Paradigmi.Libreria.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services
    .AddWebServices(builder.Configuration)
    .AddModelServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();
