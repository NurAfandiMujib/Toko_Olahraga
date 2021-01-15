using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Toko_Olahraga.Models;

namespace Toko_Olahraga.Controllers
{
    public class BarangsController : Controller
    {
        private readonly Kelompok5Context _context;

        public BarangsController(Kelompok5Context context)
        {
            _context = context;
        }

        // GET: Barangs
        public async Task<IActionResult> Index()
        {
            var kelompok5Context = _context.Barang.Include(b => b.IdAdminNavigation).Include(b => b.IdStaffNavigation);
            return View(await kelompok5Context.ToListAsync());
        }

        // GET: Barangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barang = await _context.Barang
                .Include(b => b.IdAdminNavigation)
                .Include(b => b.IdStaffNavigation)
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (barang == null)
            {
                return NotFound();
            }

            return View(barang);
        }

        // GET: Barangs/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin");
            ViewData["IdStaff"] = new SelectList(_context.StaffGudang, "IdStaff", "IdStaff");
            return View();
        }

        // POST: Barangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarang,NamaBarang,Harga,Stok,IdStaff,IdAdmin,Size")] Barang barang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", barang.IdAdmin);
            ViewData["IdStaff"] = new SelectList(_context.StaffGudang, "IdStaff", "IdStaff", barang.IdStaff);
            return View(barang);
        }

        // GET: Barangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barang = await _context.Barang.FindAsync(id);
            if (barang == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", barang.IdAdmin);
            ViewData["IdStaff"] = new SelectList(_context.StaffGudang, "IdStaff", "IdStaff", barang.IdStaff);
            return View(barang);
        }

        // POST: Barangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarang,NamaBarang,Harga,Stok,IdStaff,IdAdmin,Size")] Barang barang)
        {
            if (id != barang.IdBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarangExists(barang.IdBarang))
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
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", barang.IdAdmin);
            ViewData["IdStaff"] = new SelectList(_context.StaffGudang, "IdStaff", "IdStaff", barang.IdStaff);
            return View(barang);
        }

        // GET: Barangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barang = await _context.Barang
                .Include(b => b.IdAdminNavigation)
                .Include(b => b.IdStaffNavigation)
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (barang == null)
            {
                return NotFound();
            }

            return View(barang);
        }

        // POST: Barangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barang = await _context.Barang.FindAsync(id);
            _context.Barang.Remove(barang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarangExists(int id)
        {
            return _context.Barang.Any(e => e.IdBarang == id);
        }
    }
}
