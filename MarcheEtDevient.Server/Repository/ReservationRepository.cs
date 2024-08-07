using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcheEtDevient.Server.Repository;

public class ReservationRepository : IRepository<Reservation, string>
{
    private readonly ApiDBContext _contexteDeBDD;   // intialisation d'une variable de type apiDBContext
    public ReservationRepository (ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs a l'initialisation de ce repository
    public async Task<bool> Add(Reservation model)
    {
        _contexteDeBDD.Reservation.Add(model);                                         // ajout une nouvell entrée dans la BDD a partir de celle fournie dans le EndPoint(point de connection de l'api)
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD
        string id = model.id_utilisateur;                                                    // stock l'id du model dans une variable    
        return await _contexteDeBDD.Reservation.FindAsync(id) != null;               // verfication de la creation
    }

    public async Task<bool> Delete(string id)
    {
        var bddSejourSupprimer = await _contexteDeBDD.Reservation.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        if (bddSejourSupprimer == null) { return false; }                         // verfication de l'existance de cette id dans la table
        _contexteDeBDD.Reservation.Remove(bddSejourSupprimer);                        // Suprime l'entree correspondante
        await _contexteDeBDD.SaveChangesAsync();                                            // Sauvegarde des changement dans la BDD         
        return await _contexteDeBDD.Reservation.FindAsync(id) != null;                         // verfication de la supression
    }
    public async Task<IEnumerable<Reservation>> GetAll()
    {
       return await _contexteDeBDD.Reservation.ToArrayAsync();     // recupere la table dans la BDD et la transforme en IEnumerable                                                                             // retourne le IEnumerable
    }

    public async Task<Reservation> GetById(string id)
    {
        return await _contexteDeBDD.Reservation.FindAsync(id);     // retourne l'entrée en BDD par sont id si inexistant revoie un null
    }

    public async Task<bool> Update( Reservation model, string id)
    {
        var dbReservation = await _contexteDeBDD.Reservation.FindAsync(id);  // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        
        dbReservation.id_utilisateur = model.id_utilisateur;                    // remplace le nom du  sejour dans la bdd par celle du model
        dbReservation.id_sejour = model.id_sejour;
        dbReservation.nombre_places_demandee = model.nombre_places_demandee;
        dbReservation.date_paiement = model.date_paiement;
        dbReservation.total_reservation = model.total_reservation;
        dbReservation.validation_reservation = model.validation_reservation;
        dbReservation.numero_reservation = model.numero_reservation;
        dbReservation.min_participant = model.min_participant;
        dbReservation.max_participant = model.max_participant;



        await _contexteDeBDD.SaveChangesAsync();                                      // Sauvegarde des changement dans la BDD
        var dbVerifAction = await _contexteDeBDD.Reservation.FindAsync(id);      // recherche de l'id qui est en parrametre dans la BDD et le stock dans une variable
        return dbVerifAction.id_utilisateur == model.id_utilisateur &&                   // remplace le nom du  sejour dans la bdd par celle du model
        dbVerifAction.id_sejour == model.id_sejour &&
        dbVerifAction.nombre_places_demandee == model.nombre_places_demandee &&
        dbVerifAction.date_paiement == model.date_paiement &&
        dbVerifAction.total_reservation == model.total_reservation &&
        dbVerifAction.validation_reservation == model.validation_reservation &&
        dbVerifAction.numero_reservation == model.numero_reservation &&
        dbVerifAction.min_participant == model.min_participant &&
        dbVerifAction.max_participant == model.max_participant;   // verification de la modification
    }
}


