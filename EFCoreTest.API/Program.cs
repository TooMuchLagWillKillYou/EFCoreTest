using EFCoreTest.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthwindDBContext>(
        options => options.UseSqlServer("name=ConnectionStrings:Northwind"));

builder.Services.AddCors(options =>
        options.AddDefaultPolicy(builder => builder.WithOrigins("https://localhost:3000/")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .WithOrigins("http://localhost:3000"));

app.UseAuthorization();

app.MapControllers();

app.Run();
