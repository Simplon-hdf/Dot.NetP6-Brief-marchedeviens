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
        int id = model.IdSejour;                                                    // stock l'id du model dans une variable    
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
        dbSejour.NomSejour = model.NomSejour;                    // remplace le nom du  sejour dans la bdd par celle du model
        dbSejour.DescriptifSejour = model.DescriptifSejour;                    // remplace le descriptif dans la bdd par celle du model
        dbSejour.LieuDepartSejour = model.LieuDepartSejour;
        dbSejour.DateDebutSejour = model.DateDebutSejour;           // remplace la date debut sejour dans la bdd par celle du model
        dbSejour.DateFinSejour = model.DateFinSejour;
        dbSejour.NomLieuSejour = model.NomLieuSejour;
        dbSejour.PrixSejour = model.PrixSejour;
        dbSejour.MinParticipantSejour = model.MinParticipantSejour;
        dbSejour.MaxParticipantSejour = model.MaxParticipantSejour;
        dbSejour.TotalParticipantActuelSejour = model.TotalParticipantActuelSejour;
        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
        var dbVerifAction = await _contexteDeBDD.Sejour.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        return dbVerifAction.NomSejour == model.NomSejour &&   
                dbVerifAction.DescriptifSejour == model.DescriptifSejour &&
                dbVerifAction.LieuDepartSejour == model.LieuDepartSejour &&
                dbVerifAction.DateDebutSejour == model.DateDebutSejour &&
                dbVerifAction.DateFinSejour == model.DateFinSejour &&
                dbVerifAction.NomLieuSejour == model.NomLieuSejour &&
                dbVerifAction.PrixSejour == model.PrixSejour &&
                dbVerifAction.MinParticipantSejour == model.MinParticipantSejour &&
                dbVerifAction.MaxParticipantSejour == model.MaxParticipantSejour &&
                dbVerifAction.TotalParticipantActuelSejour == model.TotalParticipantActuelSejour;// verification de la modification
    }
}