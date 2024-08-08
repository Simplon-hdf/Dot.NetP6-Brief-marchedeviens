using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using MarcheEtDevient.Server.Data;
namespace MarcheEtDevient.Server.Repository;

public class PublicationRepository : IRepository<Publication, int>
{
    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public PublicationRepository(ApiDBContext context) =>  _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async Task<bool> Add(Publication model)
    {
        _contexteDeBDD.Publication.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
        int id = model.IdPublication;                                                    // stock l'id du model dans une variable    
        return await _contexteDeBDD.Publication.FindAsync(id) != null;                 // verfication de la creation
    }

    public async Task<bool> Delete(int id)
    {
        var bddPublicationActuSupprimer = await _contexteDeBDD.Publication.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if ( bddPublicationActuSupprimer == null){return false; }                                   // verfication de l'existance de cette id dans la table
        _contexteDeBDD.Publication.Remove(bddPublicationActuSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                                    // Sauvegarde des changement dans la BDD         
        return await _contexteDeBDD.Publication.FindAsync(id) != null;                         // verfication de la supression
    }

    public async Task<IEnumerable<Publication>> GetAll()
    {
        IEnumerable<Publication> publicationActu = await _contexteDeBDD.Publication.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
        return publicationActu;                                                                                 // retourne le IEnumerable
    }

    public async Task<Publication> GetById(int id)
    {
        return await _contexteDeBDD.Publication.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
    }

    public async Task<bool> Update(Publication model, int id)
    {
        var dbPublicationActu = await _contexteDeBDD.Publication.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        dbPublicationActu.DatePublication = model.DatePublication;                    // remplace la date de publication dans la bdd par celle du model
        dbPublicationActu.IdContenuPublie = model.IdContenuPublie;                    // remplace l'id de publication dans la bdd par celle du model
        dbPublicationActu.IdVideo = model.IdVideo;                                    // remplace l'id de la video dans la bdd par celle du model
        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD

        var dbVerifAction = await _contexteDeBDD.Publication.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable

        return dbVerifAction.IdVideo == model.IdVideo ||
            dbVerifAction.IdContenuPublie == model.IdContenuPublie;                       // verfication de la modification

    }
}
