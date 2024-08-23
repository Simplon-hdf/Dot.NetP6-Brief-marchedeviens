using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.ModelsDTO;
using MarcheEtDevient.Server.Repository;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MarcheEtDevient.Server.Controllers
{
    public class AuthentificationControlleur : ControllerBase
    {
        private readonly IAuthentificationRepository _authRepository;
        private readonly ApiDBContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthentificationControlleur(ApiDBContext dataContext, IAuthentificationRepository authconfig, IConfiguration configuration)
        {
            _authRepository = authconfig;
            _dataContext = dataContext;
            _configuration = configuration;
        }

        [HttpPost("Inscription")]
        public IActionResult Register(InscriptionDTO request)
        {
            // Valider les données d'entrée
            if (string.IsNullOrEmpty(request.mailUtilisateur) || string.IsNullOrEmpty(request.motDePasse))
            {
                return BadRequest(new { message = "Username and password are required." });
            }

            // Créer un nouvel utilisateur
            var newUser = new Utilisateur
            {
                MailUtilisateur = request.mailUtilisateur,
                MdpUtilisateur = request.motDePasse, 
                PrenomUtilisateur = request.prenomUtilisateur,
                NomUtilisateur = request.nomUtilisateur,
                AgeUtilisateur = request.ageUtilisateur,
                TelUtilisateur = request.nTelephoneUtilisateur,
                DateCreationUtilisateur = DateOnly.FromDateTime(DateTime.Now).ToString(),
                PermissionUtilisateur = "user",
            };

            // Enregistrer l'utilisateur
            _authRepository.InscriptionUtilisateur(newUser);

            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("Connection")]
        public async Task<ActionResult<Utilisateur>> ConnecterLogin(LoginDTO request)
        {
            //si requête est vide ou un champs vide, envoie d'une erreur
            if (request == null || string.IsNullOrEmpty(request.mailUtilisateur) || string.IsNullOrEmpty(request.motDePasse))
            {
                return BadRequest("formulaire incomplet");
            }

            // recherche du mail dans la bdd et assignation à la variable utilisateur
            var utilisateur = await _dataContext.Utilisateur.FirstOrDefaultAsync(r => r.MailUtilisateur == request.mailUtilisateur);

            // si utilisateur n'est pas trouvé ou si le mdp est incorrect, renvoie d'un message
            if (utilisateur == null)
            {

                return BadRequest("Mail ou Mot de passe  incorrect");
            }
            try
            {
                
                //retour d'un utilisateur
                return Ok(new { Utilisateur = utilisateur });                                                    

            }
            // si "try" à échouer, envoie d'une erreur  
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur du serveur : {ex.Message} - {ex.StackTrace}");
            }
        }

        // méthode qui vérifie si le hash et salt du mdp entrée sur le formulaire est identique à celui de la database
        private bool VerifyPasswordHash(string Password, byte[] motDePasseHash, byte[] motDePasseSalt)
        {
            // utilisation de la cle de cryptage sha512
            using (var hmac = new HMACSHA512(motDePasseSalt))
            {
                // hash du mot de passe 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return computedHash.SequenceEqual(motDePasseHash);
            }
        }

        // fonction de creation de token
        private string CreationToken(Utilisateur user)
        {
            // création de claim
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Email, user.MailUtilisateur),
                new Claim(ClaimTypes.Role, "User")
            };
            // génération du token
            var secretKey = _configuration.GetValue<string>("Token");
            // vérification si token est existant
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("La clé secrète du token n'est pas configurée.");
            }
            // génération de la clé pour le token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // génération de la signature pour le token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // génération de la structure token avec les claims, credentials et la date d'expiration
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            // création du token
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            //renvoie du token
            return jwt;
        }

        /*[HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO requete)
        {
            byte[] HashMdp = Encoding.UTF8.GetBytes(requete.motDePasse);
            var user = _authRepository.GetUserByUsernameAndPassword(requete.mailUtilisateur, HashMdp);
            *//*if (utilisateur.MailUtilisateur != requete.mailUtilisateur)
                return BadRequest("User not found");

            if (!VerifyPasswordHash(requete.motDePasse, utilisateur.mdpHash, utilisateur.mdpSalt))
                return BadRequest("Wrong password");*//*
            if (user == null)
            {
                return Unauthorized(new { message = "Mail ou mot-de-passe incorrect" });
            }
            string token = CreateToken(utilisateur);
            return Ok(new { message = "Connection réussi", UtilisateurDTO = user });
        }*/


    }

}
