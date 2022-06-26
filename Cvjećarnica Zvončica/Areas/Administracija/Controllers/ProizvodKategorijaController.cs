using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize(Roles = "Admin")]
    public class ProizvodKategorijaController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public ProizvodKategorijaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int proizvodId)
        {
            var proizvodKategorija = (from pk in _dbContext.ProizvodKategorija
                                      where pk.ProizvodId == proizvodId
                                      select new ProizvodKategorija
                                      {
                                          Id = pk.Id,
                                          ProizvodId = pk.ProizvodId,
                                          NazivProizvoda = (from p in _dbContext.Proizvod where p.Id == pk.ProizvodId select p.Naziv).FirstOrDefault(),
                                          KategorijaId = pk.KategorijaId,
                                          NazivKategorije = (from k in _dbContext.Kategorija where k.Id == pk.KategorijaId select k.Naziv).FirstOrDefault()
                                      }).ToList();

            ViewBag.ProizvodId = proizvodId;
            return View(proizvodKategorija);
        }

        [HttpGet]
        public IActionResult Kreiraj(int proizvodId)
        {
            ViewBag.ProizvodId = proizvodId;
            ViewBag.Kategorije = GetCategories();

            return View();
        }

        [HttpPost]
        public IActionResult Kreiraj(ProizvodKategorija proizvodKategorija)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProizvodKategorija.Add(proizvodKategorija);
                _dbContext.SaveChanges();

                // Nakon sto spremimo kategoriju za proizvod, preusmjeravamo na Index akcijsku metodu s ProductId kako bi vidjeli povezanu kategoriju na proizvodu
                return RedirectToAction(nameof(Index), new { proizvodId = proizvodKategorija.ProizvodId });
            }
            return View(proizvodKategorija);
        }

        public IActionResult Brisi(int id)
        {
            var productCategory = _dbContext.ProizvodKategorija.Find(id);
            _dbContext.ProizvodKategorija.Remove(productCategory);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index), new { proizvodId = productCategory.ProizvodId });
        }



        private List<SelectListItem> GetCategories()
        {
            var categories = _dbContext.Kategorija.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Naziv
            }).ToList();

            return categories;
        }
    }
}
