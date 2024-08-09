using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using static MarcheEtDevient.Server.ModelsDTO.LoginDTO;

namespace MarcheEtDevient.Server.Controllers
{
    public class AuthentificationControlleur : ControllerBase
    {
        public static Utilisateur utilisateur = new Utilisateur();
        private readonly IConfiguration _configuration;

        public AuthentificationControlleur(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private void CreatePasswordHash(string mdp, out byte[] mdpHash, out byte[] mdpSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                mdpSalt = hmac.Key;
                mdpHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(mdp));
            }
        }

        private bool VerifyPasswordHash(string mdp, byte[] mdpHash, byte[] mdpSalt)
        {
            using (var hmac = new HMACSHA512(mdpSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(mdp));
                return computedHash.SequenceEqual(mdpHash);
            }
        }

        private string CreateToken(Utilisateur user)
        {
            List <Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.MailUtilisateur),
                new Claim(ClaimTypes.Role, "Admin")
             };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                                   claims: claims,
                                   expires: DateTime.UtcNow.AddDays(1),
                                   signingCredentials: cred
   );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


        [HttpPost("register")]
        public async Task<ActionResult<Utilisateur>> Register(UtilisateurDTO request)
        {
            CreatePasswordHash(request.Mdp, out byte[] passwordHash, out byte[] passwordSalt);
            utilisateur.MailUtilisateur = request.Mail;
            utilisateur.mdpHash = passwordHash;
            utilisateur.mdpSalt = passwordSalt;

            return Ok(utilisateur);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO requete)
        {
            if (utilisateur.MailUtilisateur != requete.mailUtilisateur)
                return BadRequest("User not found");

            if (!VerifyPasswordHash(requete.motDePasse, utilisateur.mdpHash, utilisateur.mdpSalt))
                return BadRequest("Wrong password");

            string token = CreateToken(utilisateur);

            return Ok(token);
        }
    }
}
