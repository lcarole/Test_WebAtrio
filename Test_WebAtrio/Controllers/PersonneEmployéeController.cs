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
    public class PersonneEmployéeController : ControllerBase
    {
        private readonly TestWebAtrioContext _context;

        public PersonneEmployéeController(TestWebAtrioContext context)
        {
            _context = context;
        }

        // GET: api/PersonneEmployée
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonneEmployée>>> GetPersonneEmployées()
        {
            return await _context.PersonneEmployées.ToListAsync();
        }

        // GET: api/PersonneEmployée/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonneEmployée>> GetPersonneEmployée(int id)
        {
            var personneEmployée = await _context.PersonneEmployées.FindAsync(id);

            if (personneEmployée == null)
            {
                return NotFound();
            }

            return personneEmployée;
        }

        // POST: api/PersonneEmployée
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonneEmployée>> PostPersonneEmployée(PersonneEmployée personneEmployée)
        {
            _context.PersonneEmployées.Add(personneEmployée);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonneEmployée", new { id = personneEmployée.PersonneEmployee }, personneEmployée);
        }

        private bool PersonneEmployéeExists(int id)
        {
            return _context.PersonneEmployées.Any(e => e.PersonneEmployee == id);
        }
    }
}
