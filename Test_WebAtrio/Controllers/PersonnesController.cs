using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_WebAtrio.DbContexts;
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

        // GET: api/Personnes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personne>>> GetPersonnes()
        {
            Task < ActionResult < IEnumerable < Personne >>> task = GetPersonnesAsync();
            return await _context.Personnes.OrderBy(personne => personne.Nom).ThenBy(personne => personne.Prenom).ToListAsync();
        }

        // POST: api/Personnes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personne>> AddPersonne(Personne personne)
        {
            //Vérifie que la personne à moins de 150 ans
            if (personne.DateDeNaissance < DateTime.Now.AddYears(-150))
            {
                return BadRequest("La personne à plus de 150 ans");
            }
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
