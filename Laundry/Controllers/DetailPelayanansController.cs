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
    public class DetailPelayanansController : Controller
    {
        private readonly LaundryContext _context;

        public DetailPelayanansController(LaundryContext context)
        {
            _context = context;
        }

        // GET: DetailPelayanans
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetailPelayanan.ToListAsync());
        }

        // GET: DetailPelayanans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailPelayanan = await _context.DetailPelayanan
                .FirstOrDefaultAsync(m => m.IdKaryawan == id);
            if (detailPelayanan == null)
            {
                return NotFound();
            }

            return View(detailPelayanan);
        }

        // GET: DetailPelayanans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetailPelayanans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKaryawan,IdPesanan")] DetailPelayanan detailPelayanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailPelayanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detailPelayanan);
        }

        // GET: DetailPelayanans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailPelayanan = await _context.DetailPelayanan.FindAsync(id);
            if (detailPelayanan == null)
            {
                return NotFound();
            }
            return View(detailPelayanan);
        }

        // POST: DetailPelayanans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKaryawan,IdPesanan")] DetailPelayanan detailPelayanan)
        {
            if (id != detailPelayanan.IdKaryawan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailPelayanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailPelayananExists(detailPelayanan.IdKaryawan))
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
            return View(detailPelayanan);
        }

        // GET: DetailPelayanans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailPelayanan = await _context.DetailPelayanan
                .FirstOrDefaultAsync(m => m.IdKaryawan == id);
            if (detailPelayanan == null)
            {
                return NotFound();
            }

            return View(detailPelayanan);
        }

        // POST: DetailPelayanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailPelayanan = await _context.DetailPelayanan.FindAsync(id);
            _context.DetailPelayanan.Remove(detailPelayanan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailPelayananExists(int id)
        {
            return _context.DetailPelayanan.Any(e => e.IdKaryawan == id);
        }
    }
}
