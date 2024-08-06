using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using static MarcheEtDevient.Server.Repository.IRepository;
using MarcheEtDevient.Server.Data;

namespace MarcheEtDevient.Server.Repository
{
    public class UtilisateurRepository : IRepository<Utilisateur, string>
    {
        private readonly ApiDBContext _contexteDeBDD;   // initialisation d'une variable de type ApiDBContext
        public UtilisateurRepository(ApiDBContext context) => _contexteDeBDD = context;     // ajout du contexte de program.cs à l'initialisation de ce repository

        public async Task<bool> Add(Utilisateur model)
        {
            _contexteDeBDD.Utilisateurs.Add(model);                             // ajout d'une nouvelle entrée dans la BDD à partir de celle fournie dans le EndPoint (point de connexion de l'API)
            await _contexteDeBDD.SaveChangesAsync();                            // sauvegarde des changements dans la BDD
            string id = model.IdUtilisateur;                                    // stock l'id du model dans une variable
            return await _contexteDeBDD.Utilisateurs.FindAsync(id) != null;     // vérification de la création
        }

        public async Task<bool> Delete(string id)
        {
            var bddUtilisateurSupprimer = await _contexteDeBDD.Utilisateurs.FindAsync(id);      // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            if (bddUtilisateurSupprimer == null) { return false; }                              // vérification de l'existence de cet id dans la table
            _contexteDeBDD.Utilisateurs.Remove(bddUtilisateurSupprimer);                        // supprime l'entrée correspondante
            await _contexteDeBDD.SaveChangesAsync();                                            // sauvegarde des changements dans la BDD         
            return await _contexteDeBDD.Utilisateurs.FindAsync(id) != null;                     // vérification de la suppression
        }

        public async Task<IEnumerable<Utilisateur>> GetAll()
        {
            IEnumerable<Utilisateur> utilisateurs = await _contexteDeBDD.Utilisateurs.ToArrayAsync();   // récupère la table dans la BDD et la transforme en IEnumerable 
            return utilisateurs;                                                                        // retourne le IEnumerable
        }

        public async Task<Utilisateur> GetById(string id)
        {
            return await _contexteDeBDD.Utilisateurs.FindAsync(id);     // retourne l'entrée en BDD par son id, si inexistant renvoie un null
        }

        public async Task<bool> Update(Utilisateur model, string id)
        {
            var dbUtilisateur = await _contexteDeBDD.Utilisateurs.FindAsync(id);    // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            if (dbUtilisateur == null)
            {
                return false;
            }
            dbUtilisateur.MdpUtilisateur = model.MdpUtilisateur;                        // remplace le mot de passe de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.NomUtilisateur = model.NomUtilisateur;                        // remplace le nom de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.MailUtilisateur = model.MailUtilisateur;                      // remplace l'email de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.PrenomUtilisateur = model.PrenomUtilisateur;                  // remplace le prénom de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.TelUtilisateur = model.TelUtilisateur;                        // remplace le téléphone de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.AgeUtilisateur = model.AgeUtilisateur;                        // remplace l'âge de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.PermissionUtilisateur = model.PermissionUtilisateur;          // remplace les permissions de l'utilisateur dans la BDD par celles du model
            await _contexteDeBDD.SaveChangesAsync();                                    // sauvegarde des changements dans la BDD
            var dbVerifAction = await _contexteDeBDD.Utilisateurs.FindAsync(id);        // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            return dbVerifAction != null &&
                   dbVerifAction.MdpUtilisateur == model.MdpUtilisateur &&
                   dbVerifAction.NomUtilisateur == model.NomUtilisateur &&
                   dbVerifAction.MailUtilisateur == model.MailUtilisateur &&
                   dbVerifAction.PrenomUtilisateur == model.PrenomUtilisateur &&
                   dbVerifAction.TelUtilisateur == model.TelUtilisateur &&
                   dbVerifAction.AgeUtilisateur == model.AgeUtilisateur &&
                   dbVerifAction.PermissionUtilisateur == model.PermissionUtilisateur;  // vérification de la modification
        }
    }
}