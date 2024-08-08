using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarcheEtDevient.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationController : ControllerBase
    {
        private readonly PublicationRepository _publicationActuRepository;
        private readonly ApiDBContext _context;
        public PublicationController(ApiDBContext context)
        {
            _context = context;
            _publicationActuRepository = new PublicationRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> GetAllPublicationActus() 
        {
            var publicationActus = await _publicationActuRepository.GetAll();      // recupere depuis le repository toute les donnée 
            return Ok(publicationActus);                            // retourne vers le front les donnée recupérée
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> GetPublicationActu(int id)
        {
            var publicationActu = await _publicationActuRepository.GetById(id);    // recupere les donnée depuis le repository
            if (publicationActu == null)                            // si les donner sont null on  found vers le endpoint
            {
                return NotFound();                                  // retourne un notfound vers le endpoint (code 404)
            }
            return Ok(publicationActu);                             // retourne vers le front les donnée recupérée (code 200)
        }

        [HttpPost]
        public async Task<ActionResult<Publication>> CreatePublicationActu(Publication publicationActu)
        {
            var result = await _publicationActuRepository.Add(publicationActu);                                                                    // envoie vers le repository l'objet et stock le boolean de retour
            if (result)                                                                                                             // si le boolean de retour est true
            {
                return CreatedAtAction(nameof(GetPublicationActu), new { id = publicationActu.IdPublication }, publicationActu);    // revoi vers le endpoint l'object qui vien d'etre crée
            }
            return BadRequest();                                                                                                    // revoie un bad request (code ~400)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublicationActu(int id, Publication publicationActu)
        {
            if (id != publicationActu.IdPublication)                        // verifie si la donnée que lon veux update est bien celle avec cette id
            {
                return BadRequest();                                        // revoie un bad request (code ~400)
            }

            var result = await _publicationActuRepository.Update(publicationActu, id);     // envoi ves le repository l'objet a update et sont id
            if (result)
            {
                return Ok("Modification reussi");                           // revoi un ok (code ~200) 
            }
            return NotFound();                                              // revoie un not found (code 404)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicationActu(int id)
        {
            var result = await _publicationActuRepository.Delete(id);      // envoi un requete de deletion vers le repository et stock le retour
            if (result)                                     // si le retour est positive
            {
                return Ok("Supression reussi");             // revoi un ok (code ~200) 
            }
            return NotFound();                              // revoie un not found (code 404)
        }
    }
}