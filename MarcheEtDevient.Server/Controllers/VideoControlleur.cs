using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.Repository;
using Microsoft.AspNetCore.Mvc;
using static MarcheEtDevient.Server.Repository.IRepository;

namespace MarcheEtDevient.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IRepository<Video, string> _VideoRepository;
        private readonly ApiDBContext apiDBContext;
        public VideosController(ApiDBContext context)
        {
            apiDBContext = context;
            _VideoRepository = new VideoRepository(apiDBContext);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetAllVideos()
        {
            var videos = await _VideoRepository.GetAll();      // récupère depuis le repository toutes les données 
            return Ok(videos);                            // retourne vers le front les données récupérées
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(string id)
        {
            var video = await _VideoRepository.GetById(id);     // récupère les données depuis le repository
            if (video == null)                                  // si les données sont null on renvoie NotFound vers le endpoint
            {
                return NotFound();                              // retourne un NotFound vers le endpoint (code 404)
            }
            return Ok(video);                                    // retourne vers le front les données récupérées (code 200)
        }

        [HttpPost]
        public async Task<ActionResult<Video>> CreateVideo(Video video)
        {
            var result = await _VideoRepository.Add(video);                                                     // envoie vers le repository l'objet et stocke le booléen de retour
            if (result)                                                                                         // si le booléen de retour est true
            {
                return CreatedAtAction(nameof(GetVideo), new { id = video.IdVideo }, video);                    // renvoie vers le endpoint l'objet qui vient d'être créé
            }
            return BadRequest();                                                                                // renvoie un BadRequest (code ~400)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideo(string id, Video video)
        {
            if (id != video.IdVideo)                                        // vérifie si la donnée que l'on veut mettre à jour est bien celle avec cet id
            {
                return BadRequest();                                        // renvoie un BadRequest (code ~400)
            }

            var result = await _VideoRepository.Update(video, id);          // envoie vers le repository l'objet à mettre à jour et son id
            if (result)
            {
                return Ok("Modification réussie");                          // renvoie un Ok (code ~200) 
            }
            return NotFound();                                              // renvoie un NotFound (code 404)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(string id)
        {
            var result = await _VideoRepository.Delete(id);     // envoie une requête de suppression vers le repository et stocke le retour
            if (result)                                         // si le retour est positif
            {
                return Ok("Suppression réussie");               // renvoie un Ok (code ~200) 
            }
            return NotFound();                                  // renvoie un NotFound (code 404)
        }
    }
}