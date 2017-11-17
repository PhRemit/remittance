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
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index(int? SelectedState)
        {
            var applicationDbContext = _context.City.Include(s => s.State);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .Include(e => e.State)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            PopulateStateDropDownList();
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,PostalCode,Active,StateId")] City city)
        {
            if (_context.City.Any(e => e.Code == city.Code))
            {
                ModelState.AddModelError("Code", "Code already exists.");
            }
            if (_context.City.Any(e => e.Name == city.Name))
            {
                ModelState.AddModelError("Name", "Name already exists.");
            }
            if (_context.City.Any(e => e.PostalCode == city.PostalCode))
            {
                ModelState.AddModelError("PostalCode", "Postal Code already exists.");
            }
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateStateDropDownList(city.StateId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.SingleOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            PopulateStateDropDownList(city.StateId);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,PostalCode,Active,StateId")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (_context.City.Any(e => e.Code == city.Code && e.Id != city.Id))
            {
                ModelState.AddModelError("Code", "Code already exists.");
            }
            if (_context.City.Any(e => e.Name == city.Name && e.Id != city.Id))
            {
                ModelState.AddModelError("Name", "Name already exists.");
            }
            if (_context.City.Any(e => e.PostalCode == city.PostalCode && e.Id != city.Id))
            {
                ModelState.AddModelError("PostalCode", "Postal Code already exists.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            PopulateStateDropDownList(city.StateId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .Include(s => s.State)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.City.SingleOrDefaultAsync(m => m.Id == id);
            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Id == id);
        }

        private void PopulateStateDropDownList(object selectedState = null)
        {
            var stateQuery = from c in _context.State
                               orderby c.Name
                               select c;
            ViewBag.StateId = new SelectList(stateQuery, "Id", "Name", selectedState);
        }
    }
}
