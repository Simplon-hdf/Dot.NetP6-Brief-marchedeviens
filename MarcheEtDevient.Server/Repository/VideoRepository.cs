using MarcheEtDevient.Server.Models;
using Microsoft.EntityFrameworkCore;
using MarcheEtDevient.Server.Data;

namespace MarcheEtDevient.Server.Repository
{
    public class VideoRepository : IRepository<Video, string>
    {
        private readonly ApiDBContext _contexteDeBDD;                               // initialisation d'une variable de type ApiDBContext
        public VideoRepository(ApiDBContext context) => _contexteDeBDD = context;   // ajout du contexte de program.cs à l'initialisation de ce repository

        public async Task<bool> Add(Video model)
        {
            _contexteDeBDD.Video.Add(model);                           // ajout d'une nouvelle entrée dans la BDD à partir de celle fournie dans le EndPoint (point de connexion de l'API)
            await _contexteDeBDD.SaveChangesAsync();                    // sauvegarde des changements dans la BDD
            string id = model.id_video;                                  // stock l'id du model dans une variable
            return await _contexteDeBDD.Video.FindAsync(id) != null;   // vérification de la création
        }

        public async Task<bool> Delete(string id)
        {
            var bddVideoSupprimer = await _contexteDeBDD.Video.FindAsync(id);  // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            if (bddVideoSupprimer == null) { return false; }                    // vérification de l'existence de cet id dans la table
            _contexteDeBDD.Video.Remove(bddVideoSupprimer);                    // supprime l'entrée correspondante
            await _contexteDeBDD.SaveChangesAsync();                            // sauvegarde des changements dans la BDD         
            return await _contexteDeBDD.Video.FindAsync(id) != null;           // vérification de la suppression
        }

        public async Task<IEnumerable<Video>> GetAll()
        {
            IEnumerable<Video> videos = await _contexteDeBDD.Video.ToArrayAsync();     // récupère la table dans la BDD et la transforme en IEnumerable 
            return videos;                                                              // retourne le IEnumerable
        }

        public async Task<Video> GetById(string id)
        {
            return await _contexteDeBDD.Video.FindAsync(id);       // retourne l'entrée en BDD par son id, si inexistant renvoie un null
        }

        public async Task<bool> Update(Video model, string id)
        {
            var dbVideo = await _contexteDeBDD.Video.FindAsync(id);        // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            dbVideo.date_sortie = model.date_sortie;                          // remplace la date de publication dans la BDD par celle du model
            dbVideo.lien_video = model.lien_video;                            // remplace l'id de vidéo dans la BDD par celle du model
            dbVideo.titre_video = model.titre_video;                          // remplace le titre de la vidéo dans la BDD par celui du model
            dbVideo.id_sejour = model.id_sejour; //                           // remplace l'id du sejour de la vidéo dans la BDD par celui du model
            await _contexteDeBDD.SaveChangesAsync();                        // sauvegarde des changements dans la BDD
            var dbVerifAction = await _contexteDeBDD.Video.FindAsync(id);  // recherche de l'id qui est en paramètre dans la BDD et le stock dans une variable
            return dbVerifAction.date_sortie == model.date_sortie &&
                   dbVerifAction.lien_video == model.lien_video &&
                   dbVerifAction.titre_video == model.titre_video &&
                   dbVerifAction.id_sejour == model.id_sejour;                // vérification de la modification
        }
    }
}