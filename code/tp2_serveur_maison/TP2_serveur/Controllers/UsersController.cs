using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TP2_serveur.DTOs;
using TP2_serveur.Models;

namespace TP2_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            // Tenter de trouver l'utilisateur dans la BD à partir de son pseudo
            User? user = await _userManager.FindByNameAsync(login.Username);

            // Si l'utilisateur existe ET que son mot de passe est exact
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                // Récupérer les rôles de l'utilisateur (Cours 22+)
                IList<string> roles = await _userManager.GetRolesAsync(user);
                List<Claim> authClaims = new List<Claim>();
                foreach (string role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                // Générer et chiffrer le token 
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes("LooOOongue Phrase SiNoN Ça ne Marchera PaAaAAAaAas !")); // Phrase identique dans Program.cs
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "http://localhost:5143", // ⛔ Vérifiez le PORT de votre serveur dans launchSettings.json !
                    audience: "http://localhost:3000",
                    claims: authClaims,
                    expires: DateTime.Now.AddMinutes(30), // Durée de validité du token
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                    );

                // Envoyer le token à l'application cliente sous forme d'objet JSON
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    validTo = token.ValidTo
                });
            }
            // Utilisateur inexistant ou mot de passe incorrecte
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Le nom d'utilisateur ou le mot de passe est invalide." });
            }
        }
    }
}
