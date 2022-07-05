﻿using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class KorisnikController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IPasswordHasher<ApplicationUser> _passwordHasher;

        public KorisnikController(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Index()
        {
            var korisnici = _userManager.Users.ToList();
            return View(korisnici);
        }

        [HttpGet]
        public IActionResult Kreiraj()
        {
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
                return View(korisnik);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(string id, string email, string password, string ime, string prezime, string adresa)
        {
            ApplicationUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                if (!string.IsNullOrEmpty(ime))
                {
                    appUser.Ime = ime;
                }
                else
                {
                    ModelState.AddModelError("", "Ime je obavezno.");
                }

                if (!string.IsNullOrEmpty(prezime))
                {
                    appUser.Prezime = prezime;
                }
                else
                {
                    ModelState.AddModelError("", "Prezime je obavezno.");
                }

                appUser.Adresa = adresa;

                if (!string.IsNullOrEmpty(email))
                {
                    appUser.Email = email;
                }
                else
                {
                    ModelState.AddModelError("", "Email je obavezan.");
                }

                if (!string.IsNullOrEmpty(password))
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, password);
                }
                else
                {
                    ModelState.AddModelError("", "Lozinka je obavezna.");
                }

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(appUser);

                    if (result.Succeeded)
                    {
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
            return View(appUser);
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
