﻿using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Models;
using MarcheEtDevient.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarcheEtDevient.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly ApiDBContext _context;
        private readonly VideoRepository _repository;
        public VideosController(ApiDBContext context)
        {
            _context = context;
            _repository = new VideoRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetAllVideos()
        {
            var videos = await _repository.GetAll();      // récupère depuis le repository toutes les données 
            return Ok(videos);                            // retourne vers le front les données récupérées
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(int id)
        {
            var video = await _repository.GetById(id);     // récupère les données depuis le repository
            if (video == null)                                  // si les données sont null on renvoie NotFound vers le endpoint
            {
                return NotFound();                              // retourne un NotFound vers le endpoint (code 404)
            }
            return Ok(video);                                    // retourne vers le front les données récupérées (code 200)
        }

        [HttpPost]
        public async Task<ActionResult<Video>> CreateVideo(Video video)
        {
            var result = await _repository.Add(video);                                                     // envoie vers le repository l'objet et stocke le booléen de retour
            if (result)                                                                                         // si le booléen de retour est true
            {
                return CreatedAtAction(nameof(GetVideo), new { id = video.IdVideo }, video);                    // renvoie vers le endpoint l'objet qui vient d'être créé
            }
            return BadRequest();                                                                                // renvoie un BadRequest (code ~400)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideo(int id, Video video)
        {
            if (id != video.IdVideo)                                        // vérifie si la donnée que l'on veut mettre à jour est bien celle avec cet id
            {
                return BadRequest();                                        // renvoie un BadRequest (code ~400)
            }

            var result = await _repository.Update(video, id);          // envoie vers le repository l'objet à mettre à jour et son id
            if (result)
            {
                return Ok("Modification réussie");                          // renvoie un Ok (code ~200) 
            }
            return NotFound();                                              // renvoie un NotFound (code 404)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var result = await _repository.Delete(id);     // envoie une requête de suppression vers le repository et stocke le retour
            if (result)                                         // si le retour est positif
            {
                return Ok("Suppression réussie");               // renvoie un Ok (code ~200) 
            }
            return NotFound();                                  // renvoie un NotFound (code 404)
        }
    }
}