using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vincible.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VincibleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VincibleContext") ?? throw new InvalidOperationException("Connection string 'VincibleContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
    o.AddPolicy("Allow all", p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
