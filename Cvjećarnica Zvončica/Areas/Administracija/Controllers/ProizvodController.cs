using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize(Roles = "Admin")]
    public class ProizvodController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ProizvodController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var proizvodi = _dbContext.Proizvod.ToList();

            return View(proizvodi);
        }

        [HttpGet]
        public IActionResult Kreiraj()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Kreiraj(Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                if (proizvod.SlikaFile != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        proizvod.SlikaFile.CopyTo(stream);
                        var file = stream.ToArray();

                        proizvod.Slika = file;
                    }
                }

                _dbContext.Proizvod.Add(proizvod);
                _dbContext.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }

            return View(proizvod);
        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            var proizvod = _dbContext.Proizvod.Find(id);
            return View(proizvod);
        }

        [HttpPost]
        public IActionResult Uredi(Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                if (proizvod.SlikaFile != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        proizvod.SlikaFile.CopyTo(stream);
                        var file = stream.ToArray();

                        proizvod.Slika = file;
                    }
                }

                _dbContext.Proizvod.Update(proizvod);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(proizvod);
        }

        [HttpGet]
        public IActionResult Brisi(int id)
        {
            var proizvod = _dbContext.Proizvod.Find(id);
            return View(proizvod);
        }

        [HttpPost]
        public IActionResult BrisiPotvrdi(int id)
        {
            var proizvod = _dbContext.Proizvod.Find(id);
            _dbContext.Proizvod.Remove(proizvod);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
