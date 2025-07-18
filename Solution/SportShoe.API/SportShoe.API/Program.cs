using Microsoft.EntityFrameworkCore;
using SportShoeManagement.API.Data;
using SportShoeManagement.API.Models;
using SportShoeManagement.API.Interfaces;
using SportShoeManagement.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Đăng ký DbContext (có thể tách extension method nếu muốn)
builder.Services.AddDbContext<SportShoeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký Service
builder.Services.AddScoped<ISportShoeService, SportShoeService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
