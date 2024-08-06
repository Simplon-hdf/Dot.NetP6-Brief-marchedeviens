using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using static MarcheEtDevient.Server.Repository.IRepository;
using MarcheEtDevient.Server.Data;
namespace MarcheEtDevient.Server.Repository;

public class PublicationActusRepository : IRepository<PublicationActu, string>
{
    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public PublicationActusRepository(ApiDBContext context) =>  _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async Task<bool> Add(PublicationActu model)
    {
        _contexteDeBDD.PublicationActus.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
        string id = model.IdPublication;                                                    // stock l'id du model dans une variable    
        return await _contexteDeBDD.PublicationActus.FindAsync(id) != null;                 // verfication de la creation
    }

    public async Task<bool> Delete(string id)
    {
        var bddPublicationActuSupprimer = await _contexteDeBDD.PublicationActus.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if ( bddPublicationActuSupprimer == null){return false; }                                   // verfication de l'existance de cette id dans la table
        _contexteDeBDD.PublicationActus.Remove(bddPublicationActuSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                                    // Sauvegarde des changement dans la BDD         
        return await _contexteDeBDD.PublicationActus.FindAsync(id) != null;                         // verfication de la supression
    }

    public async Task<IEnumerable<PublicationActu>> GetAll()
    {
        IEnumerable<PublicationActu> publicationActu = await _contexteDeBDD.PublicationActus.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
        return publicationActu;                                                                                 // retourne le IEnumerable
    }

    public async Task<PublicationActu> GetById(string id)
    {
        return await _contexteDeBDD.PublicationActus.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
    }

    public async Task<bool> Update(PublicationActu model, string id)
    {
        var dbPublicationActu = await _contexteDeBDD.PublicationActus.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        dbPublicationActu.DatePublication = model.DatePublication;                    // remplace la date de publication dans la bdd par celle du model
        dbPublicationActu.IdPublication = model.IdPublication;                    // remplace l'id de publication dans la bdd par celle du model
        dbPublicationActu.IdVideo = model.IdVideo;                                    // remplace l'id de la video dans la bdd par celle du model
        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
        var dbVerifAction = await _contexteDeBDD.PublicationActus.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        return dbVerifAction.IdVideo == model.IdVideo ||
            dbVerifAction.IdPublication == model.IdPublication;                       // verfication de la modification

    }
}
