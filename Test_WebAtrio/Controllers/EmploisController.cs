using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_WebAtrio.DbContexts;
using Test_WebAtrio.DTO;
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

        ///<summary>
        /// Renvoie tout les emplois
        /// </summary>
        /// <returns></returns>
        // GET: api/Emplois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmplois()
        {
            return await _context.Emplois.ToListAsync();
        }

        /// <summary>
        /// Renvoie tous les emplois d'une personne entre deux plages de dates.
        /// </summary>
        /// <param name="idPersonne"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <returns></returns>
        // GET: api/Emplois/5
        [HttpGet("Personne/{idPersonne}")]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmploiByPersonneAndDate(int idPersonne, [FromQuery] DateTime? dateDebut, [FromQuery] DateTime? dateFin)
        {
            //Renvoient tous les emplois d'une personne entre deux plages de dates.
            if (dateDebut != null && dateFin != null)
            {
                return await _context.Emplois
                    .Where(emploi => emploi.PersonneEmployées.Any(personneEmployée => personneEmployée.PersonneId == idPersonne && personneEmployée.DateDebut >= dateDebut && personneEmployée.DateDebut <= dateFin))
                    .ToListAsync();
            }
            return BadRequest("Veuillez spécifier tout les paramètres.");

        }

        /// <summary>
        /// Ajoute un emploi dans la base.
        /// </summary>
        /// <param name="emploi"></param>
        /// <returns></returns>
        // POST: api/Emplois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emploi>> PostEmploi(EmploiDTO emploiDTO)
        {
            var emploi = new Emploi()
            {
                Poste = emploiDTO.Poste,
                Entreprise = emploiDTO.Entreprise
            };
            _context.Emplois.Add(emploi);
            await _context.SaveChangesAsync();

            return Created();
        }
    }
}
