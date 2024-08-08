using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using MarcheEtDevient.Server.Data;
namespace MarcheEtDevient.Server.Repository;
    public class PhotoRepository : IRepository<Photo, string>
    {

    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public PhotoRepository(ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async Task<bool> Add(Photo model)
    {
        _contexteDeBDD.Photo.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
        int id = model.IdPhoto;                                                    // stock l'id du model dans une variable    
        return await _contexteDeBDD.Photo.FindAsync(id) != null;                 // verfication de la creation
    }

    public async Task<bool> Delete(string id)
    {
        var bddPhotoSupprimer = await _contexteDeBDD.Photo.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if (bddPhotoSupprimer == null) { return false; }                                   // verfication de l'existance de cette id dans la table
        _contexteDeBDD.Photo.Remove(bddPhotoSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                                    // Sauvegarde des changement dans la BDD         
        return await _contexteDeBDD.Photo.FindAsync(id) != null;                         // verfication de la supression
    }

    public async Task<IEnumerable<Photo>> GetAll()
    {
        IEnumerable<Photo> photo = await _contexteDeBDD.Photo.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
        return photo;                                                                                 // retourne le IEnumerable
    }

    public async Task<Photo> GetById(string id)
    {
        return await _contexteDeBDD.Photo.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
    }

    public async Task<bool> Update(Photo model, string id)
    {
        var dbPhoto = await _contexteDeBDD.Photo.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        dbPhoto.DatePhoto = model.DatePhoto;                    // remplace la date de publication dans la bdd par celle du model
        dbPhoto.EstPubliquePhoto = model.EstPubliquePhoto;                    // remplace la photo dans la bdd par celle du model
        dbPhoto.DonneePhoto = model.DonneePhoto;                                    // remplace la determination publique de la photo dans la bdd par celle du model
        dbPhoto.IdSejour = model.IdSejour;
        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
        var dbVerifAction = await _contexteDeBDD.Photo.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        return dbVerifAction.DatePhoto == model.DatePhoto &&
            dbVerifAction.EstPubliquePhoto == model.EstPubliquePhoto &&
            dbVerifAction.DonneePhoto == model.DonneePhoto &&
            dbVerifAction.IdSejour == model.IdSejour;                       // verfication de la modification
    }
}
