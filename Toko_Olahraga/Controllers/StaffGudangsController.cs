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
    public class StaffGudangsController : Controller
    {
        private readonly Kelompok5Context _context;

        public StaffGudangsController(Kelompok5Context context)
        {
            _context = context;
        }

        // GET: StaffGudangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffGudang.ToListAsync());
        }

        // GET: StaffGudangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffGudang = await _context.StaffGudang
                .FirstOrDefaultAsync(m => m.IdStaff == id);
            if (staffGudang == null)
            {
                return NotFound();
            }

            return View(staffGudang);
        }

        // GET: StaffGudangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffGudangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStaff,NamaStaff,NoTlp,Alamat")] StaffGudang staffGudang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffGudang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffGudang);
        }

        // GET: StaffGudangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffGudang = await _context.StaffGudang.FindAsync(id);
            if (staffGudang == null)
            {
                return NotFound();
            }
            return View(staffGudang);
        }

        // POST: StaffGudangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStaff,NamaStaff,NoTlp,Alamat")] StaffGudang staffGudang)
        {
            if (id != staffGudang.IdStaff)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffGudang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffGudangExists(staffGudang.IdStaff))
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
            return View(staffGudang);
        }

        // GET: StaffGudangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffGudang = await _context.StaffGudang
                .FirstOrDefaultAsync(m => m.IdStaff == id);
            if (staffGudang == null)
            {
                return NotFound();
            }

            return View(staffGudang);
        }

        // POST: StaffGudangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffGudang = await _context.StaffGudang.FindAsync(id);
            _context.StaffGudang.Remove(staffGudang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffGudangExists(int id)
        {
            return _context.StaffGudang.Any(e => e.IdStaff == id);
        }
    }
}
