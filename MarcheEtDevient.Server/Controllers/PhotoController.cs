using MarcheEtDevient.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MarcheEtDevient.Server.Repository.IRepository;

namespace MarcheEtDevient.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IRepository<Photo, string> _repository;

        public PhotoController(IRepository<Photo, string> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetAllPhoto()
        {
            var photo = await _repository.GetAll();      // recupere depuis le repository toute les donnée 
            return Ok(photo);                            // retourne vers le front les donnée recupérée
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetPhoto(string id)
        {
            var photo = await _repository.GetById(id);    // recupere les donnée depuis le repository
            if (photo == null)                            // si les donner sont null on  found vers le endpoint
            {
                return NotFound();                                  // retourne un notfound vers le endpoint (code 404)
            }
            return Ok(photo);                             // retourne vers le front les donnée recupérée (code 200)
        }

        [HttpPost]
        public async Task<ActionResult<Photo>> CreatePhoto(Photo photo)
        {
            var result = await _repository.Add(photo);                                                                    // envoie vers le repository l'objet et stock le boolean de retour
            if (result)                                                                                                             // si le boolean de retour est true
            {
                return CreatedAtAction(nameof(GetPhoto), new { id = photo.IdPhoto }, photo);    // revoi vers le endpoint l'object qui vien d'etre crée
            }
            return BadRequest();                                                                                                    // revoie un bad request (code ~400)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublicationActu(string id, Photo photo)
        {
            if (id != photo.IdPhoto)                        // verifie si la donnée que lon veux update est bien celle avec cette id
            {
                return BadRequest();                                        // revoie un bad request (code ~400)
            }

            var result = await _repository.Update(photo, id);     // envoi ves le repository l'objet a update et sont id
            if (result)
            {
                return Ok("Modification reussi");                           // revoi un ok (code ~200) 
            }
            return NotFound();                                              // revoie un not found (code 404)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicationActu(string id)
        {
            var result = await _repository.Delete(id);      // envoi un requete de deletion vers le repository et stock le retour
            if (result)                                     // si le retour est positive
            {
                return Ok("Supression reussi");             // revoi un ok (code ~200) 
            }
            return NotFound();                              // revoie un not found (code 404)
        }
    }
}
