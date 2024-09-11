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
    public class PersonneEmployéeController : ControllerBase
    {
        private readonly TestWebAtrioContext _context;

        public PersonneEmployéeController(TestWebAtrioContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permet d'ajouter un emploi à une personne avec une date de début et de fin d'emploi. Pour le poste actuellement occupé, la date de fin n'est pas obligatoire. Une personne peut avoir plusieurs emplois aux dates qui se chevauchent.
        /// </summary>
        /// <param name="personneEmployéeDTO"></param>
        /// <returns></returns>
        // POST: api/PersonneEmployée
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonneEmployée>> PostPersonneEmployée(PersonneEmployéeDTO personneEmployéeDTO)
        {
            var personneEmployee = new PersonneEmployée()
            {
                PersonneId = personneEmployéeDTO.PersonneId,
                EmploiId = personneEmployéeDTO.EmploiId,
                DateDebut = personneEmployéeDTO.DateDebut,
                DateFin = personneEmployéeDTO.DateFin
            };

            _context.PersonneEmployées.Add(personneEmployee);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonneEmployéeExists(personneEmployéeDTO.EmploiId, personneEmployee.PersonneId))
                {
                    return Conflict("L'employé pour ce poste a déja été insérée.");
                }
                else
                {
                    throw;
                }
            }

            return Created();
        }

        private bool PersonneEmployéeExists(int EmploiId, int personneId)
        {
            return _context.PersonneEmployées.Any(e => e.EmploiId == EmploiId && e.PersonneId == personneId);
        }
    }
}
