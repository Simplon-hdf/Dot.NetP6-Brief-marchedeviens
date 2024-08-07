using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using MarcheEtDevient.Server.Data;
namespace MarcheEtDevient.Server.Repository;

public class PublicationActusRepository : IRepository<PublicationActu, string>
{
    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public PublicationActusRepository(ApiDBContext context) =>  _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async Task<bool> Add(PublicationActu model)
    {
        _contexteDeBDD.Publication_Actu.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
        string id = model.id_publication;                                                    // stock l'id du model dans une variable    
        return await _contexteDeBDD.Publication_Actu.FindAsync(id) != null;                 // verfication de la creation
    }

    public async Task<bool> Delete(string id)
    {
        var bddPublicationActuSupprimer = await _contexteDeBDD.Publication_Actu.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if ( bddPublicationActuSupprimer == null){return false; }                                   // verfication de l'existance de cette id dans la table
        _contexteDeBDD.Publication_Actu.Remove(bddPublicationActuSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                                    // Sauvegarde des changement dans la BDD         
        return await _contexteDeBDD.Publication_Actu.FindAsync(id) != null;                         // verfication de la supression
    }

    public async Task<IEnumerable<PublicationActu>> GetAll()
    {
        IEnumerable<PublicationActu> publicationActu = await _contexteDeBDD.Publication_Actu.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
        return publicationActu;                                                                                 // retourne le IEnumerable
    }

    public async Task<PublicationActu> GetById(string id)
    {
        return await _contexteDeBDD.Publication_Actu.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
    }

    public async Task<bool> Update(PublicationActu model, string id)
    {
        var dbPublicationActu = await _contexteDeBDD.Publication_Actu.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        dbPublicationActu.date_publication = model.date_publication;                    // remplace la date de publication dans la bdd par celle du model
        dbPublicationActu.id_publication = model.id_publication;                    // remplace l'id de publication dans la bdd par celle du model
        dbPublicationActu.id_video = model.id_video;                                    // remplace l'id de la video dans la bdd par celle du model
        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
        var dbVerifAction = await _contexteDeBDD.Publication_Actu.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        return dbVerifAction.id_video == model.id_video ||
            dbVerifAction.id_publication == model.id_publication;                       // verfication de la modification

    }
}
