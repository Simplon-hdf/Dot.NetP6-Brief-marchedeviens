using MarcheEtDevient.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MarcheEtDevient.Server.Repository.IRepository;


namespace MarcheEtDevient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartenirGalerieController : ControllerBase
    {
        private readonly IRepository<AppartenirGalerie, string> _repository; // on part du interface qui reprend les parametres model et type 

        public AppartenirGalerieController(IRepository<AppartenirGalerie, string> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppartenirGalerie>>> GetAll()
        {
            var appartenirGalerie = await _repository.GetAll();      // recupere depuis le repository toute les donnée 
            return Ok(appartenirGalerie);                            // retourne vers le front les donnée recupérée
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppartenirGalerie>> GetAppartenirGalerie(string id)
        {
            var appartenirGalerie = await _repository.GetById(id);    // recupere les donnée depuis le repository
            if (appartenirGalerie == null)                            // si les donnees sont null on  found vers le endpoint
            {
                return NotFound();                                  // retourne un notfound vers le endpoint (code 404)
            }
            return Ok(appartenirGalerie);                             // retourne vers le front les donnée recupérée (code 200)
        }

        [HttpPost]
        public async Task<ActionResult<AppartenirGalerie>> CreateAppartenirGalerie(AppartenirGalerie appartenirGalerie)
        {
            var result = await _repository.Add(appartenirGalerie);                                                                    // envoie vers le repository l'objet et stock le boolean de retour
            if (result)                                                                                                             // si le boolean de retour est true
            {
                return CreatedAtAction(nameof(GetAppartenirGalerie), new { id = appartenirGalerie.IdSejour }, appartenirGalerie);    // revoi vers le endpoint l'object qui vien d'etre crée
            }
            return BadRequest();                                                                                                    // revoie un bad request (code ~400)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppartenirGalerie(string id, AppartenirGalerie appartenirGalerie)
        {
            if (id != appartenirGalerie.IdSejour)                        // verifie si la donnée que lon veux update est bien celle avec cette id
            {
                return BadRequest();                                        // revoie un bad request (code ~400)
            }

            var result = await _repository.Update(appartenirGalerie, id);     // envoi ves le repository l'objet a update et sont id
            if (result)
            {
                return Ok("Modification reussie");                           // revoi un ok (code ~200) 
            }
            return NotFound();                                              // revoie un not found (code 404)
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppartenirGalerie(string id)
        {
            var result = await _repository.Delete(id);      // envoi un requete de deletion vers le repository et stock le retour
            if (result)                                     // si le retour est positif
            {
                return Ok("Supression reussie");             // revoi un ok (code ~200) 
            }
            return NotFound();                              // revoie un not found (code 404)
        }

    }
}
