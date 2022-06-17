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
    public class KategorijaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public KategorijaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var kategorije = _dbContext.Kategorija.ToList();
            return View(kategorije);
        }

        [HttpGet]
        public IActionResult Kreiraj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kreiraj(Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Kategorija.Add(kategorija);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(kategorija);
        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            var kategorija = _dbContext.Kategorija.Find(id);
            return View(kategorija);
        }

        [HttpPost]
        public IActionResult Uredi(Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Kategorija.Update(kategorija);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(kategorija);
        }

        [HttpGet]
        public IActionResult Brisi(int id)
        {
            var kategorija = _dbContext.Kategorija.Find(id);
            return View(kategorija);
        }

        [HttpPost]
        public IActionResult BrisiPotvrdi(int id)
        {
            var kategorija = _dbContext.Kategorija.Find(id);
            _dbContext.Kategorija.Remove(kategorija);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
