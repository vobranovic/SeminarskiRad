using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cvjećarnica_Zvončica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ProizvodiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Proizvod>> Proizvodi()
        {
            var proizvodi = _dbContext.Proizvod.Select(p => new { p.Id, p.Naziv, p.Kolicina, p.Cijena, p.Opis });
            try
            {
                return Ok(proizvodi);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Greška u dohvatu podataka iz baze podataka.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Proizvod> Proizvod(int id)
        {
            var proizvod = _dbContext.Proizvod.Select(p => new { p.Id, p.Naziv, p.Kolicina, p.Cijena, p.Opis }).FirstOrDefault(pr => pr.Id == id);
            try
            {
                return Ok(proizvod);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Greška u dohvatu podataka iz baze podataka.");
            }
        }
        
    }
}
