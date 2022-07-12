using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize(Roles = "Admin")]
    public class KorisnikController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IPasswordHasher<ApplicationUser> _passwordHasher;        

        public KorisnikController(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var korisnici = _userManager.Users.ToList();
            return View(korisnici);
        }

        [HttpGet]
        public IActionResult Kreiraj()
        {
            ViewBag.Role = _roleManager.Roles.ToList().Select(r => new SelectListItem()
            { 
                Text = r.Name, Value = r.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kreiraj(KorisnikViewModel korisnik)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = korisnik.Email,
                    Email = korisnik.Email,
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Adresa = korisnik.Adresa
                };
                

                IdentityResult identityResult = await _userManager.CreateAsync(appUser, korisnik.Password);

                if (identityResult.Succeeded)
                {
                    var odabranaRola = _roleManager.Roles.FirstOrDefault(r => r.Id == korisnik.Rola);
                    await _userManager.AddToRoleAsync(appUser, odabranaRola.Name);
                    appUser.Rola = odabranaRola.Name;
                    await _userManager.UpdateAsync(appUser);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Errors(identityResult);
                }
            }
            return View(korisnik);
        }

        [HttpGet]
        public async Task<IActionResult> Uredi(string id)
        {
            ApplicationUser korisnik = await _userManager.FindByIdAsync(id);

            if (korisnik != null)
            {
                ViewBag.Role = _roleManager.Roles.ToList().Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Id.ToString()
                });
                return View(korisnik);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(string id, string email, string password, string ime, string prezime, string adresa, string rola)
        {
            ApplicationUser korisnik = await _userManager.FindByIdAsync(id);
            if (korisnik != null)
            {
                if (!string.IsNullOrEmpty(ime))
                {
                    korisnik.Ime = ime;
                }
                else
                {
                    ModelState.AddModelError("", "Ime je obavezno.");
                }

                if (!string.IsNullOrEmpty(prezime))
                {
                    korisnik.Prezime = prezime;
                }
                else
                {
                    ModelState.AddModelError("", "Prezime je obavezno.");
                }

                korisnik.Adresa = adresa;

                if (!string.IsNullOrEmpty(email))
                {
                    korisnik.Email = email;
                }
                else
                {
                    ModelState.AddModelError("", "Email je obavezan.");
                }

                if (!string.IsNullOrEmpty(password))
                {
                    korisnik.PasswordHash = _passwordHasher.HashPassword(korisnik, password);
                }
                else
                {
                    ModelState.AddModelError("", "Lozinka je obavezna.");
                }

                

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(korisnik);

                    if (result.Succeeded)
                    {
                        var trenutnaRola = await _userManager.GetRolesAsync(korisnik);
                        await _userManager.RemoveFromRolesAsync(korisnik, trenutnaRola);

                        var odabranaRola = _roleManager.Roles.FirstOrDefault(r => r.Id == rola);
                        await _userManager.AddToRoleAsync(korisnik, odabranaRola.Name);

                        korisnik.Rola = odabranaRola.Name;
                        await _userManager.UpdateAsync(korisnik);

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        Errors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Korisnik nije pronađen.");
            }
            return View(korisnik);
        }

        [HttpGet]
        public async Task<IActionResult> Brisi(string id)
        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                var result = await _userManager.DeleteAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Errors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Korisnik nije pronađen.");
            }

            return RedirectToAction(nameof(Index));
        }

        private void Errors(IdentityResult identityResult)
        {
            foreach (IdentityError error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }



    }
}
