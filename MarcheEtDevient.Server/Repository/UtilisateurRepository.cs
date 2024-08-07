using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using MarcheEtDevient.Server.Data;

namespace MarcheEtDevient.Server.Repository
{
    public class UtilisateurRepository : IRepository<Utilisateur, string>
    {
        private readonly ApiDBContext _contexteDeBDD;   // initialisation d'une variable de type ApiDBContext
        public UtilisateurRepository(ApiDBContext context) => _contexteDeBDD = context;     // ajout du contexte de program.cs à l'initialisation de ce repository

        public async Task<bool> Add(Utilisateur model)
        {
            _contexteDeBDD.Utilisateur.Add(model);                             // ajout d'une nouvelle entrée dans la BDD à partir de celle fournie dans le EndPoint (point de connexion de l'API)
            await _contexteDeBDD.SaveChangesAsync();                            // sauvegarde des changements dans la BDD
            string id = model.id_utilisateur;                                    // stock l'id du model dans une variable
            return await _contexteDeBDD.Utilisateur.FindAsync(id) != null;     // vérification de la création
        }

        public async Task<bool> Delete(string id)
        {
            var bddUtilisateurSupprimer = await _contexteDeBDD.Utilisateur.FindAsync(id);      // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            if (bddUtilisateurSupprimer == null) { return false; }                              // vérification de l'existence de cet id dans la table
            _contexteDeBDD.Utilisateur.Remove(bddUtilisateurSupprimer);                        // supprime l'entrée correspondante
            await _contexteDeBDD.SaveChangesAsync();                                            // sauvegarde des changements dans la BDD         
            return await _contexteDeBDD.Utilisateur.FindAsync(id) != null;                     // vérification de la suppression
        }

        public async Task<IEnumerable<Utilisateur>> GetAll()
        {
            IEnumerable<Utilisateur> utilisateurs = await _contexteDeBDD.Utilisateur.ToArrayAsync();   // récupère la table dans la BDD et la transforme en IEnumerable 
            return utilisateurs;                                                                        // retourne le IEnumerable
        }

        public async Task<Utilisateur> GetById(string id)
        {
            return await _contexteDeBDD.Utilisateur.FindAsync(id);     // retourne l'entrée en BDD par son id, si inexistant renvoie un null
        }

        public async Task<bool> Update(Utilisateur model, string id)
        {
            var dbUtilisateur = await _contexteDeBDD.Utilisateur.FindAsync(id);    // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            if (dbUtilisateur == null)
            {
                return false;
            }
            dbUtilisateur.mdp_utilisateur = model.mdp_utilisateur;                        // remplace le mot de passe de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.nom_utilisateur = model.nom_utilisateur;                        // remplace le nom de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.mail_utilisateur = model.mail_utilisateur;                      // remplace l'email de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.prenom_utilisateur = model.prenom_utilisateur;                  // remplace le prénom de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.tel_utilisateur = model.tel_utilisateur;                        // remplace le téléphone de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.age_utilisateur = model.age_utilisateur;                        // remplace l'âge de l'utilisateur dans la BDD par celui du model
            dbUtilisateur.permission_utilisateur = model.permission_utilisateur;          // remplace les permissions de l'utilisateur dans la BDD par celles du model
            await _contexteDeBDD.SaveChangesAsync();                                    // sauvegarde des changements dans la BDD
            var dbVerifAction = await _contexteDeBDD.Utilisateur.FindAsync(id);        // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            return dbVerifAction != null &&
                   dbVerifAction.mdp_utilisateur == model.mdp_utilisateur &&
                   dbVerifAction.nom_utilisateur == model.nom_utilisateur &&
                   dbVerifAction.mail_utilisateur == model.mail_utilisateur &&
                   dbVerifAction.prenom_utilisateur == model.prenom_utilisateur &&
                   dbVerifAction.tel_utilisateur == model.tel_utilisateur &&
                   dbVerifAction.age_utilisateur == model.age_utilisateur &&
                   dbVerifAction.permission_utilisateur == model.permission_utilisateur;  // vérification de la modification
        }
    }
}