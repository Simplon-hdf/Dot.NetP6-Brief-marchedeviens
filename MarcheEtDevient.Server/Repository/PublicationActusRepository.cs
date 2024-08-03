using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using static MarcheEtDevient.Server.Repository.IRepository;
using MarcheEtDevient.Server.Data;
namespace MarcheEtDevient.Server.Repository;

public class PublicationActusRepository : IRepository<PublicationActu, string>
{
    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public PublicationActusRepository(ApiDBContext context) =>  _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async void Add(PublicationActu model)
    {
        _contexteDeBDD.PublicationActus.Add(model);     // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();        // Sauvegarde des changement dans la BDD
    }

    public async void Delete(string id)
    {
        var bddPublicationActuSupprimer = await _contexteDeBDD.PublicationActus.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        _contexteDeBDD.PublicationActus.Remove(bddPublicationActuSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                                    // Sauvegarde des changement dans la BDD
    }

    public async Task<IEnumerable<PublicationActu>> GetAll()
    {
        IEnumerable<PublicationActu> publicationActu = await _contexteDeBDD.PublicationActus.ToListAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
        return publicationActu;                                                                                 // retourne le IEnumerable
    }

    public async Task<PublicationActu> GetById(string id)
    {
        PublicationActu publicationActu = await _contexteDeBDD.PublicationActus.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if (publicationActu == null) { return null; }                                               // si publicationActu est null on retourne null
        return publicationActu;                                                                     // retourne publicationActu
    }

    public async void Update(PublicationActu model, string id)
    {
        var dbPublicationActu = await _contexteDeBDD.PublicationActus.FindAsync(id);    // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        dbPublicationActu.DatePublication = model.DatePublication;                      // remplace la date de publication dans la bdd par celle du model
        dbPublicationActu.IdPublicationActu = model.IdPublication;                      // remplace l'id de publication dans la bdd par celle du model
        dbPublicationActu.IdVideo = model.IdVideo;                                      // remplace l'id de la video dans la bdd par celle du model
        await _contexteDeBDD.SaveChangesAsync();                                        // Sauvegarde des changement dans la BDD
    }
}
