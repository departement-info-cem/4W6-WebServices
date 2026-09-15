using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TP2_serveur.Data;
using TP2_serveur.Models;
using TP2_serveur.Spotify;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TP2_serveurContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("TP2_serveurContext") ?? throw new InvalidOperationException("Connection string 'serveur16Context' not found."));
    options.UseLazyLoadingProxies(); // Ceci
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TP2_serveurContext>();

builder.Services.AddAuthentication(options =>
{
    // Indiquer à ASP.NET Core que nous procéderons à l'authentification par le biais d'un JWT
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    options.SaveToken = true; // Sauvegarder les tokens côté serveur pour pouvoir valider leur authenticité
    options.RequireHttpsMetadata = false; // Lors du développement on peut laisser à false
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = SpotifyCredentials.Audience, // Audience : Client
        ValidIssuer = SpotifyCredentials.Issuer, // ⛔ Issuer : Serveur -> HTTPS VÉRIFIEZ le PORT de votre serveur dans launchsettings.json !
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(SpotifyCredentials.SigningKey)) // Clé pour déchiffrer les tokens
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Les requêtes /v1/... et /api/token qui ne correspondent à aucune route doivent
// répondre une erreur JSON, comme le fait Spotify.
app.UseSpotifyEndpointErrors();

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

