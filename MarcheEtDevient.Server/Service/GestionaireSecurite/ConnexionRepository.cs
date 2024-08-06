using MarcheEtDevient.Server.Data;
using Microsoft.IdentityModel.JsonWebTokens;
using MarcheEtDevient.Server.Models;
using System.Net.Mail;
using System.Diagnostics.Eventing.Reader;

namespace MarcheEtDevient.Server.Service.GestionaireSecurite
{
    public class ConnexionRepository
    {
        private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
        public ConnexionRepository(ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository

        async Task<JsonWebToken?> ActionConnexion(string mailUtilisateur,string motDePasse)
        {
            Utilisateur? utilisateurDemandeConnexion = _contexteDeBDD.Utilisateurs.Local.Where<Utilisateur>(b => b.MailUtilisateur == mailUtilisateur).FirstOrDefault();
            if (utilisateurDemandeConnexion == null) { return null; }
            else if (MdpHash.PassHash(motDePasse) != utilisateurDemandeConnexion.MdpUtilisateur)
            {
                return null;
            }
            else
            {
                //retrun le jwt
            };
        }
    }
}
