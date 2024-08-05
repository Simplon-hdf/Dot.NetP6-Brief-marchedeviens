using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using static MarcheEtDevient.Server.Repository.IRepository;

namespace MarcheEtDevient.Server.Repository
{
    public class ContenuPublieRepository : IRepository<ContenuPublie, string>
    {
        private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
        public ContenuPublieRepository(ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
        public async Task<bool> Add(ContenuPublie model)
        {
            _contexteDeBDD.ContenuPublies.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
            await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
            string id = model.IdPublication;                                                    // stock l'id du model dans une variable    
            return await _contexteDeBDD.ContenuPublies.FindAsync(id) != null;                 // verfication de la creation
        }

        public async Task<bool> Delete(string id)
        {
            var bddContenuPublieSupprimer = await _contexteDeBDD.ContenuPublies.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
            if (bddContenuPublieSupprimer == null) { return false; }                                   // verfication de l'existance de cette id dans la table
            _contexteDeBDD.ContenuPublies.Remove(bddContenuPublieSupprimer);                        // Suprime l'entree correspondante
            await _contexteDeBDD.SaveChangesAsync();                                                    // Sauvegarde des changement dans la BDD         
            return await _contexteDeBDD.ContenuPublies.FindAsync(id) != null;                         // verfication de la supression
        }

        public async Task<IEnumerable<ContenuPublie>> GetAll()
        {
            IEnumerable<ContenuPublie> contenuPublie = await _contexteDeBDD.ContenuPublies.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
            return contenuPublie;                                                                                 // retourne le IEnumerable
        }

        public async Task<ContenuPublie> GetById(string id)
        {
            return await _contexteDeBDD.ContenuPublies.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
        }

        public async Task<bool> Update(ContenuPublie model, string id)
        {
            var dbCOntenuPublie = await _contexteDeBDD.ContenuPublies.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
            dbCOntenuPublie.DateCslv = model.DateCslv;                    // remplace la date de publication dans la bdd par celle du model
            dbCOntenuPublie.Theme = model.Theme;                    // remplace le theme dans la bdd par celle du model
            dbCOntenuPublie.Commentaire = model.Commentaire;                                    // remplace le commentaire de la publication dans la bdd par celle du model
            await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
            var dbVerifAction = await _contexteDeBDD.ContenuPublies.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
            return dbVerifAction.IdPublication == model.IdPublication;
        }
    }
}
