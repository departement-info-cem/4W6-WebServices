using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DixCordesServeur.Data;
using DixCordesServeur.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DixCordesServeurContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DixCordesServeurContext") ?? 
        throw new InvalidOperationException("Connection string 'DixCordesServeurContext' not found."));
    options.UseLazyLoadingProxies();
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DixCordesServeurContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false; // Lors du développement
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = "http://localhost:3000", // Client -> HTTP
        ValidIssuer = "https://localhost:7253", // Serveur -> HTTPS
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
        .GetBytes("LooOOongue Phrase SiNoN Ça ne Marchera PaAaAAAaAas !"))
    };
});


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
