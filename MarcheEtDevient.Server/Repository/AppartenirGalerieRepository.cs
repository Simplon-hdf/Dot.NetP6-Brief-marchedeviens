using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using static MarcheEtDevient.Server.Repository.IRepository;


namespace MarcheEtDevient.Server.Repository
{
    public class AppartenirGalerieRepository : IRepository<AppartenirGalerie, string>
    {
        private readonly ApiDBContext _contexteDeBDD;                           // intialisation d'une variable de type apiDBContext
        public AppartenirGalerieRepository(ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
        public async Task<bool> Add(AppartenirGalerie model)
        {
            _contexteDeBDD.AppartenirGaleries.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
            await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
            string id = model.IdSejour;                                                    // stock l'id du model dans une variable    
            return await _contexteDeBDD.AppartenirGaleries.FindAsync(id) != null;               // verfication de la creation
        }
        public async Task<bool> Delete(string id)
        {
            var bddAppartenirGalerieSupprimer = _contexteDeBDD.AppartenirGaleries.Local.Where<AppartenirGalerie>(b => b.IdSejour == id).FirstOrDefault(); //
            if (bddAppartenirGalerieSupprimer == null) { return false; }                         // verfication de l'existance de cette id dans la table
            _contexteDeBDD.AppartenirGaleries.Remove(bddAppartenirGalerieSupprimer);                        // Suprime l'entree correspondante
            await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD         
            return await _contexteDeBDD.AppartenirGaleries.FindAsync(id) != null;                         // verfication de la supression
        }

        public async Task<IEnumerable<AppartenirGalerie>> GetAll()
        {
            IEnumerable<AppartenirGalerie> appartenirGaleries = await _contexteDeBDD.AppartenirGaleries.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
            return appartenirGaleries;                                                                                 // retourne le IEnumerable
        }

        public async Task<AppartenirGalerie> GetById(string id)
        {
            return await _contexteDeBDD.AppartenirGaleries.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
        }

        public async Task<bool> Update(AppartenirGalerie model, string id)
        {
            var dbAppartenirGalerie = await _contexteDeBDD.AppartenirGaleries.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
            dbAppartenirGalerie.IdSejour = model.IdSejour;                    // remplace le nom du  sejour dans la bdd par celle du model
            dbAppartenirGalerie.IdPhoto = model.IdPhoto;                    // remplace le descriptif dans la bdd par celle du model
            await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
            var dbVerifAction = await _contexteDeBDD.AppartenirGaleries.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
            return dbVerifAction.IdSejour == model.IdSejour;   // verification de la modification         
        }


    }
}
