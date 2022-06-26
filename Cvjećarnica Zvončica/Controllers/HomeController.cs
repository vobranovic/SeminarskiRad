using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(int? kategorijaId)
        {
            var proizvodi = _dbContext.Proizvod.ToList();

            if (kategorijaId != null)
            {
                proizvodi =
                    (
                       from p in _dbContext.Proizvod
                       join pk in _dbContext.ProizvodKategorija on p.Id equals pk.ProizvodId
                       where pk.KategorijaId == kategorijaId
                       select new Proizvod
                       {
                           Id = p.Id,
                           Naziv = p.Naziv,
                           Opis = p.Opis,                           
                           Cijena = p.Cijena
                       }
                    ).ToList();
            }

            ViewBag.Kategorije = _dbContext.Kategorija.Select
                (
                   c => new SelectListItem
                   {
                       Value = c.Id.ToString(),
                       Text = c.Naziv
                   }
                );
            return View(proizvodi);
        }

        public IActionResult Kontakt()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
