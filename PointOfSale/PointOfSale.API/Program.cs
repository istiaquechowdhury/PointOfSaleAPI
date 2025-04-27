using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PointOfSale.API;
using PointOfSale.Infrastructure.ApplicationDB;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Better than AddOpenApi for Swashbuckle
builder.Services.AddSwaggerGen(); // Add Swagger generator

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var migrationAssembly = typeof(ApplicationDbContext).Assembly.GetName().Name;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseNpgsql(connectionString));

// Autofac setup
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
{
    ContainerBuilder.RegisterModule(new WebModule(connectionString, migrationAssembly));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // generate swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PointOfSale API v1");
        c.RoutePrefix = "swagger"; // So you can visit /swagger
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

