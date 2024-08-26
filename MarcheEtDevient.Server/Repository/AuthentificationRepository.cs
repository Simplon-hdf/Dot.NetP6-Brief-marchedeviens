using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace MarcheEtDevient.Server.Repository 
{
    public class AuthentificationRepository : IAuthentificationRepository
    {
        private readonly ApiDBContext _contexteDeBDD;   
        public AuthentificationRepository(ApiDBContext context) => _contexteDeBDD = context;   

        public Utilisateur Connexion(string mail, string password)
        {
            return _contexteDeBDD.Utilisateur.FirstOrDefault(u => u.MailUtilisateur == mail && u.MdpUtilisateur == password);  /*HashPassword(password)*/
        }

        public void InscriptionUtilisateur(Utilisateur user)
        {
            _contexteDeBDD.Utilisateur.Add(user);
            _contexteDeBDD.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                var hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
