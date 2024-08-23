using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.ModelsDTO;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MarcheEtDevient.Server.Repository
{
    public interface IAuthentificationRepository
    {
        Utilisateur Connexion(string mail, string password);
        void InscriptionUtilisateur(Utilisateur user);
    }
}
