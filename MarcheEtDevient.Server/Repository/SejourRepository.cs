using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcheEtDevient.Server.Repository;

public class SejourRepository : IRepository <Sejour, string>
{
    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public SejourRepository(ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async Task<bool> Add(Sejour model)
    {
        _contexteDeBDD.Sejour.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
        string id = model.id_sejour;                                                    // stock l'id du model dans une variable    
        return await _contexteDeBDD.Sejour.FindAsync(id) != null;               // verfication de la creation
    }

    public async Task<bool> Delete(string id)
    {
        var bddSejourSupprimer = await _contexteDeBDD.Sejour.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if (bddSejourSupprimer == null) { return false; }                         // verfication de l'existance de cette id dans la table
        _contexteDeBDD.Sejour.Remove(bddSejourSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD         
        return await _contexteDeBDD.Sejour.FindAsync(id) != null;                         // verfication de la supression
    }
    public async Task<IEnumerable<Sejour>> GetAll()
    {
        IEnumerable<Sejour> sejour = await _contexteDeBDD.Sejour.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable 
        return sejour;                                                                                 // retourne le IEnumerable
    }

    public async Task<Sejour> GetById(string id)
    {
        return await _contexteDeBDD.Sejour.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
    }

    public async Task<bool> Update(Sejour model, string id)
    {
        var dbSejour = await _contexteDeBDD.Sejour.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        dbSejour.nom_sejour = model.nom_sejour;                    // remplace le nom du  sejour dans la bdd par celle du model
        dbSejour.descriptif = model.descriptif;                    // remplace le descriptif dans la bdd par celle du model
        dbSejour.date_debut_sejour = model.date_debut_sejour;           // remplace la date debut sejour dans la bdd par celle du model
        dbSejour.date_fin_sejour = model.date_fin_sejour;
        dbSejour.nom_lieu_sejour = model.nom_lieu_sejour;
        dbSejour.prix_sejour = model.prix_sejour;
        dbSejour.type_sejour = model.type_sejour;
        dbSejour.total_participant = model.total_participant;
        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
        var dbVerifAction = await _contexteDeBDD.Sejour.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        return dbVerifAction.nom_sejour == model.nom_sejour &&   
                dbVerifAction.descriptif == model.descriptif &&
                dbVerifAction.date_debut_sejour == model.date_debut_sejour &&
                dbVerifAction.date_fin_sejour == model.date_fin_sejour &&
                dbVerifAction.nom_lieu_sejour == model.nom_lieu_sejour &&
                dbVerifAction.prix_sejour == model.prix_sejour &&
                dbVerifAction.type_sejour == model.type_sejour &&
                dbVerifAction.total_participant == model.total_participant;// verification de la modification
    }
}