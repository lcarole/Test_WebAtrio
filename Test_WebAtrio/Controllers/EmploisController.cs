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
    public class EmploisController : ControllerBase
    {
        private readonly TestWebAtrioContext _context;

        public EmploisController(TestWebAtrioContext context)
        {
            _context = context;
        }

        // GET: api/Emplois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmplois()
        {
            return await _context.Emplois.ToListAsync();
        }

        // GET: api/Emplois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emploi>> GetEmploi(int id)
        {
            var emploi = await _context.Emplois.FindAsync(id);

            if (emploi == null)
            {
                return NotFound();
            }

            return emploi;
        }

        // POST: api/Emplois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emploi>> PostEmploi(Emploi emploi)
        {
            _context.Emplois.Add(emploi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploi", new { id = emploi.EmploiId }, emploi);
        }

        private bool EmploiExists(int id)
        {
            return _context.Emplois.Any(e => e.EmploiId == id);
        }
    }
}
