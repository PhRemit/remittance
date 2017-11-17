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
    public class StatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: States
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.State.Include(s => s.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _context.State
                .Include(s => s.Country)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: States/Create
        public IActionResult Create()
        {
            PopulateCountryDropDownList();
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Active,CountryId")] State state)
        {
            if (_context.State.Any(e => e.Code == state.Code))
            {
                ModelState.AddModelError("Code", "Code already exists.");
            }
            if (_context.State.Any(e => e.Name == state.Name))
            {
                ModelState.AddModelError("Name", "Name already exists.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCountryDropDownList(state.CountryId);
            return View(state);
        }

        // GET: States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _context.State.SingleOrDefaultAsync(m => m.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            PopulateCountryDropDownList();
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Active,CountryId")] State state)
        {
            if (id != state.Id)
            {
                return NotFound();
            }

            if (_context.State.Any(e => e.Code == state.Code && e.Id != state.Id))
            {
                ModelState.AddModelError("Code", "Code already exists.");
            }
            if (_context.State.Any(e => e.Name == state.Name && e.Id != state.Id))
            {
                ModelState.AddModelError("Name", "Name already exists.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(state);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateExists(state.Id))
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
            PopulateCountryDropDownList(state.CountryId);
            return View(state);
        }

        // GET: States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await _context.State
                .Include(s => s.Country)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var state = await _context.State.SingleOrDefaultAsync(m => m.Id == id);
            _context.State.Remove(state);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StateExists(int id)
        {
            return _context.State.Any(e => e.Id == id);
        }

        private void PopulateCountryDropDownList(object selectedCountry = null)
        {
            var countryQuery = from c in _context.Country
                               orderby c.Name
                               select c;
            ViewBag.CountryId = new SelectList(countryQuery, "Id", "Name", selectedCountry);
        }
    }
}
