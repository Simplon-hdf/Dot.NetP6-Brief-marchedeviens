using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.Repository;
using Microsoft.AspNetCore.Mvc;
namespace MarcheEtDevient.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ReservationController : ControllerBase
    {
        private readonly ApiDBContext _context;
        private readonly ReservationRepository _repository;

        public ReservationController(ApiDBContext context)
        {
            _context = context;
            _repository = new ReservationRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservation()
        {
            var reservation = await _repository.GetAll();      // recupere depuis le repository toute les donnée 
            return Ok(reservation);                            // retourne vers le front les donnée recupérée
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(string id)
        {
            var reservation = await _repository.GetById(id);    // recupere les donnée depuis le repository
            if (reservation == null)                            // si les donner sont null on  found vers le endpoint
            {
                return NotFound();                                  // retourne un notfound vers le endpoint (code 404)
            }
            return Ok(reservation);                             // retourne vers le front les donnée recupérée (code 200)
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation(Reservation reservation )
        {
            var result = await _repository.Add(reservation);                                                                    // envoie vers le repository l'objet et stock le boolean de retour
            if (result)                                                                                                             // si le boolean de retour est true
            {
                return CreatedAtAction(nameof(GetReservation), new { id = reservation.id_utilisateur }, reservation);    // revoi vers le endpoint l'object qui vien d'etre crée
            }
            return BadRequest();                                                                                                    // revoie un bad request (code ~400)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(string id, Reservation reservation)
        {
            if (id != reservation.id_utilisateur)                        // verifie si la donnée que lon veux update est bien celle avec cette id
            {
                return BadRequest();                                        // revoie un bad request (code ~400)
            }

            var result = await _repository.Update(reservation, id);     // envoi ves le repository l'objet a update et sont id
            if (result)
            {
                return Ok("Modification reussi");                           // revoi un ok (code ~200) 
            }
            return NotFound();                                              // revoie un not found (code 404)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(string id)
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

