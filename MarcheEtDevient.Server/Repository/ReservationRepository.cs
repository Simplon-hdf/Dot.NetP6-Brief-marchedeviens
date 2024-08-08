using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcheEtDevient.Server.Repository;

public class ReserverRepository : IRepository<Reserver, string>
{
    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public ReserverRepository(ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async Task<bool> Add(Reserver model)
    {
        _contexteDeBDD.Reserver.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
        string id = model.IdUtilisateur;                                                    // stock l'id du model dans une variable    
        return await _contexteDeBDD.Reserver.FindAsync(id) != null;               // verfication de la creation
    }

    public async Task<bool> Delete(string id)
    {
        var bddSejourSupprimer = await _contexteDeBDD.Reserver.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if (bddSejourSupprimer == null) { return false; }                         // verfication de l'existance de cette id dans la table
        _contexteDeBDD.Reserver.Remove(bddSejourSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD         
        return await _contexteDeBDD.Reserver.FindAsync(id) != null;                         // verfication de la supression
    }
    public async Task<IEnumerable<Reserver>> GetAll()
    {
       return await _contexteDeBDD.Reserver.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable                                                                             // retourne le IEnumerable
    }

    public async Task<Reserver> GetById(string id)
    {
        return await _contexteDeBDD.Reserver.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
    }

    public async Task<bool> Update(Reserver model, string id)
    {
        var dbReservation = await _contexteDeBDD.Reserver.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        
        dbReservation.IdUtilisateur = model.IdUtilisateur;                    // remplace le nom du  sejour dans la bdd par celle du model
        dbReservation.IdSejour = model.IdSejour;
        dbReservation.IdReserver = model.IdReserver;
        dbReservation.NombrePlaceReserver = model.NombrePlaceReserver;
        dbReservation.ValidationReserver = model.ValidationReserver;
        dbReservation.DatePaiementReserver = model.DatePaiementReserver;



        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
        var dbVerifAction = await _contexteDeBDD.Reserver.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        return dbVerifAction.IdUtilisateur == model.IdUtilisateur &&                   // remplace le nom du  sejour dans la bdd par celle du model
        dbVerifAction.IdSejour == model.IdSejour &&
        dbVerifAction.IdReserver == model.IdReserver &&
        dbVerifAction.NombrePlaceReserver == model.NombrePlaceReserver &&
        dbVerifAction.ValidationReserver == model.ValidationReserver &&
        dbVerifAction.DatePaiementReserver == model.DatePaiementReserver;  // verification de la modification
    }
}


