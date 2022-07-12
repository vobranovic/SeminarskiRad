using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var role = _roleManager.Roles.ToList();
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> DodajRolu(string nazivRole)
        {
            if (nazivRole != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(nazivRole.Trim()));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Kreiraj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kreiraj(IdentityRole identityRole)
        {
            if (identityRole.Name != null)
            {
                await _roleManager.CreateAsync(identityRole);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Greska = "Greška u nazivu role. Naziv ne smije biti prazan!";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Brisi(string id)
        {
            if (id != null)
            {
                var rolaZaBrisati = await _roleManager.FindByIdAsync(id);
                await _roleManager.DeleteAsync(rolaZaBrisati);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
