using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize(Roles = "Admin")]
    public class KorisnikController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public KorisnikController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var korisnici = _dbContext.Users.ToList();
            return View(korisnici);
        }

        [HttpGet]
        public IActionResult Uredi(string id)
        {
            var korisnik = _dbContext.Users.Find(id);
            return View(korisnik);
        }

        [HttpPost]
        public IActionResult Uredi(ApplicationUser applicationUser)
        {
            var korisnik = _dbContext.Users.FirstOrDefault(k => k.Id == applicationUser.Id);
            korisnik = applicationUser;
            if (ModelState.IsValid)
            {
                _dbContext.Users.Update(korisnik);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(applicationUser);
        }

    }
}
