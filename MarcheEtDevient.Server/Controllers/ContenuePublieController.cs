using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.Repository;
using Microsoft.AspNetCore.Mvc;
namespace MarcheEtDevient.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContenuePublieController : Controller
    {
        private readonly ApiDBContext _context;
        private readonly ContenuPublieRepository _repository;
        
        public ContenuePublieController(ApiDBContext context)
        {
            _context = context;
            _repository = new ContenuPublieRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContenuPublie>>> GetAllContenuPublie()
        {
            var contenuPublie = await _repository.GetAll();      // recupere depuis le repository toute les donnée 
            return Ok(contenuPublie);                            // retourne vers le front les donnée recupérée
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContenuPublie>> GetContenu(int id)
        {
            var contenuPublie = await _repository.GetById(id);    // recupere les donnée depuis le repository
            if (contenuPublie == null)                            // si les donner sont null on  found vers le endpoint
            {
                return NotFound();                                  // retourne un notfound vers le endpoint (code 404)
            }
            return Ok(contenuPublie);                             // retourne vers le front les donnée recupérée (code 200)
        }

        [HttpPost]
        public async Task<ActionResult<ContenuPublie>> CreateContenue(ContenuPublie contenuPublie)
        {
            var result = await _repository.Add(contenuPublie);                                                                    // envoie vers le repository l'objet et stock le boolean de retour
            if (result)                                                                                                             // si le boolean de retour est true
            {
                return CreatedAtAction(nameof(GetContenu), new { id = contenuPublie.IdContenuPublie }, contenuPublie);    // revoi vers le endpoint l'object qui vien d'etre crée
            }
            return BadRequest();                                                                                                    // revoie un bad request (code ~400)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublicationActu(int id, ContenuPublie contenuPublie)
        {
            if (id != contenuPublie.IdContenuPublie)                        // verifie si la donnée que lon veux update est bien celle avec cette id
            {
                return BadRequest();                                        // revoie un bad request (code ~400)
            }

            var result = await _repository.Update(contenuPublie, id);     // envoi ves le repository l'objet a update et sont id
            if (result)
            {
                return Ok("Modification reussi");                           // revoi un ok (code ~200) 
            }
            return NotFound();                                              // revoie un not found (code 404)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicationActu(int id)
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
