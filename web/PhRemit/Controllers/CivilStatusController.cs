using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhRemit.Data;
using PhRemit.Models;

namespace PhRemit.Controllers
{
    public class CivilStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CivilStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CivilStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CivilStatus.ToListAsync());
        }

        // GET: CivilStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var civilStatus = await _context.CivilStatus
                .SingleOrDefaultAsync(m => m.Id == id);
            if (civilStatus == null)
            {
                return NotFound();
            }

            return View(civilStatus);
        }

        // GET: CivilStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CivilStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Active")] CivilStatus civilStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(civilStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(civilStatus);
        }

        // GET: CivilStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var civilStatus = await _context.CivilStatus.SingleOrDefaultAsync(m => m.Id == id);
            if (civilStatus == null)
            {
                return NotFound();
            }
            return View(civilStatus);
        }

        // POST: CivilStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Active")] CivilStatus civilStatus)
        {
            if (id != civilStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(civilStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CivilStatusExists(civilStatus.Id))
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
            return View(civilStatus);
        }

        // GET: CivilStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var civilStatus = await _context.CivilStatus
                .SingleOrDefaultAsync(m => m.Id == id);
            if (civilStatus == null)
            {
                return NotFound();
            }

            return View(civilStatus);
        }

        // POST: CivilStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var civilStatus = await _context.CivilStatus.SingleOrDefaultAsync(m => m.Id == id);
            _context.CivilStatus.Remove(civilStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CivilStatusExists(int id)
        {
            return _context.CivilStatus.Any(e => e.Id == id);
        }
    }
}
