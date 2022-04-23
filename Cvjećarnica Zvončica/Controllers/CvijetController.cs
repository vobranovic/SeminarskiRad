using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cvjećarnica_Zvončica.Data;
using Cvjećarnica_Zvončica.Models;

namespace Cvjećarnica_Zvončica.Controllers
{
    public class CvijetController : Controller
    {
        private readonly CvjecarnicaDbContext _context;

        public CvijetController(CvjecarnicaDbContext context)
        {
            _context = context;
        }

        // GET: Cvijet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cvijet.ToListAsync());
        }

        // GET: Cvijet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvijet = await _context.Cvijet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvijet == null)
            {
                return NotFound();
            }

            return View(cvijet);
        }

        // GET: Cvijet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cvijet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Boja,Datum,ImgUrl,Cijena")] Cvijet cvijet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvijet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cvijet);
        }

        // GET: Cvijet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvijet = await _context.Cvijet.FindAsync(id);
            if (cvijet == null)
            {
                return NotFound();
            }
            return View(cvijet);
        }

        // POST: Cvijet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Boja,Datum,ImgUrl,Cijena")] Cvijet cvijet)
        {
            if (id != cvijet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvijet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvijetExists(cvijet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cvijet);
        }

        // GET: Cvijet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvijet = await _context.Cvijet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvijet == null)
            {
                return NotFound();
            }

            return View(cvijet);
        }

        // POST: Cvijet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cvijet = await _context.Cvijet.FindAsync(id);
            _context.Cvijet.Remove(cvijet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvijetExists(int id)
        {
            return _context.Cvijet.Any(e => e.Id == id);
        }
    }
}
