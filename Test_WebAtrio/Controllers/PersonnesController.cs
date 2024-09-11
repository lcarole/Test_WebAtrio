using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_WebAtrio.DbContexts;
using Test_WebAtrio.DTO;
using Test_WebAtrio.Models;

namespace Test_WebAtrio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly TestWebAtrioContext _context;

        public PersonnesController(TestWebAtrioContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Renvoie toute les personnes.
        /// </summary>
        /// <returns></returns>
        // GET: api/Personnes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personne>>> GetPersonnes()
        {
            return await _context.Personnes.OrderBy(personne => personne.Nom).ThenBy(personne => personne.Prenom).ToListAsync();
        }

        /// <summary>
        /// Renvoie toutes les personnes ayant travaillé pour une entreprise donnée.
        /// </summary>
        /// <param name="idEmploi"></param>
        /// <returns></returns>
        //GET: api/Personnes/{idEmploi}
        [HttpGet("Emploi/{idEmploi}")]
        public async Task<ActionResult<IEnumerable<Personne>>> GetPersonnesByEmploi(int idEmploi)
        {
            return await _context.Personnes
                .Where(personne => personne.PersonneEmployées.Any(personneEmployée => personneEmployée.EmploiId == idEmploi))
                .OrderBy(personne => personne.Nom)
                .ThenBy(personne => personne.Prenom)
                .ToListAsync();
        }

        /// <summary>
        /// Ajoute une nouvelle personne. La personne ajouter ne doit pas avoir plus de 150 ans
        /// </summary>
        /// <param name="personne"></param>
        /// <returns></returns>
        // POST: api/Personnes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personne>> PostPersonne(PersonneDTO personneDTO)
        {
            var personne = new Personne()
            {
                Nom = personneDTO.Nom,
                Prenom = personneDTO.Prenom,
                DateDeNaissance = personneDTO.DateDeNaissance
            };
            _context.Personnes.Add(personne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonne", new { id = personne.PersonneId }, personne);
        }

        private bool PersonneExists(int id)
        {
            return _context.Personnes.Any(e => e.PersonneId == id);
        }
    }
}
