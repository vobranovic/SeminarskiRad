using Cvjećarnica_Zvončica.Baza;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Controllers
{
    public class CvijetController : Controller
    {
        private BazaCvijeca _cvijece;

        public CvijetController()
        {
            _cvijece = new BazaCvijeca();
        }

        public IActionResult PopisDostupnogCvijeca()
        {
            var cvijece1 = _cvijece.Stanje();
            var cvijece = _cvijece.PopisSvogCvijeca();
            return View(cvijece);
        }

        [HttpGet]
        public IActionResult DodajNoviCvijetUBazu()
        {
            ViewBag.BazaCvijeca = _cvijece.PopisSvogCvijeca();
            return View();
        }

        [HttpPost]
        public IActionResult DodajNoviCvijetUBazu(Cvijet cvijet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["Success"] = "Unos novog cvijeta u bazu je uspješan.";
                    ViewBag.BazaCvijeca = _cvijece.PopisSvogCvijeca();
                    _cvijece.DodajNoviCvijet(cvijet);
                    return View();
                }
                else
                {
                    ViewData["Error"] = "Greška kod unosa forme.";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.UnknownError = "Dogodila se pogreška: " + e.Message;
                return View();
            }
        }
    }
}
