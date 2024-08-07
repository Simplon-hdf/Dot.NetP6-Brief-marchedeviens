using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarcheEtDevient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SejourController : ControllerBase
    {
        private readonly ApiDBContext _context;
        private readonly SejourRepository _repository;

        public SejourController(ApiDBContext context)
        {
            _context = context;
            _repository = new SejourRepository(_context);
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAllSejour()
        {
            var sejour = await _repository.GetAll();  //recupere depuis le repo ttes les données
            return Ok(sejour);       // retourne vers le front les données récupérees
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Sejour>> GetSejour(string id)
        {
            var sejour = await _repository.GetById(id);  //recupere les données depuis le repo
            if (sejour == null)                         //si les données sont null on found vers le endpoint
            {
                return NotFound();                  //retourne un not found vers le endpoint (code 404)
            }
            return Ok(sejour);                      //retourne vers le front les données récupéree(code 200)
        }

        [HttpPost]

        public async Task<ActionResult<Sejour>> CreateSejour(Sejour sejour)
        {
            var result = await _repository.Add(sejour);             //envoie vers le repo l'objet et stock le boolean de retour
            if (result)                                             //si le boolean de retour est true
            {
                return CreatedAtAction(nameof(GetSejour), new { id = sejour.id_sejour }, sejour); // renvoi vers le endpoint l'objet qui vient d'être crée
            }
            return BadRequest();                        // envoi un badresquest (code 400)
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateSejour(string id, Sejour sejour)
        {
            if (id != sejour.id_sejour)              //vérifie si la donnée que l'on veut update est bien celle avec cet id
            {
                return BadRequest();                //rebvoie un bad request (code 400)
            }

            var result = await _repository.Update(sejour, id);// envoi vers le repository l'objet a update et son id
            if (result)
            {
                return Ok("Modificaton réussie");   // renvoi un ok(code 200)
            }

            return NotFound();   // renvoie un not found (code 404)
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSejour(string id)
        {
            var result = await _repository.Delete(id);      // envoi un requete de deletion vers le repository et stock le retour
            if (result)                                     // si le retour est positive
            {
                return Ok("Supression reussie");             // revoi un ok (code ~200) 
            }
            return NotFound();                              // revoie un not found (code 404)
        }




    }
}
