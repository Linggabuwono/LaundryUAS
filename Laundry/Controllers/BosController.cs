using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laundry.Models;

namespace Laundry.Controllers
{
    public class BosController : Controller
    {
        private readonly LaundryContext _context;

        public BosController(LaundryContext context)
        {
            _context = context;
        }

        // GET: Bos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bos.ToListAsync());
        }

        // GET: Bos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bos = await _context.Bos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bos == null)
            {
                return NotFound();
            }

            return View(bos);
        }

        // GET: Bos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Password")] Bos bos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bos);
        }

        // GET: Bos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bos = await _context.Bos.FindAsync(id);
            if (bos == null)
            {
                return NotFound();
            }
            return View(bos);
        }

        // POST: Bos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Password")] Bos bos)
        {
            if (id != bos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BosExists(bos.Id))
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
            return View(bos);
        }

        // GET: Bos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bos = await _context.Bos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bos == null)
            {
                return NotFound();
            }

            return View(bos);
        }

        // POST: Bos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bos = await _context.Bos.FindAsync(id);
            _context.Bos.Remove(bos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BosExists(int id)
        {
            return _context.Bos.Any(e => e.Id == id);
        }
    }
}
