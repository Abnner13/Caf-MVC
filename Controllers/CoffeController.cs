using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class CoffeController : Controller
    {
        private readonly MvcCoffeContext _context;

        public CoffeController(MvcCoffeContext context)
        {
            _context = context;
        }

        // GET: Coffe
        public async Task<IActionResult> Index(string CoffeHTT, string searchString)
        {
            IQueryable<string> HTTQuery = from m in _context.Coffe
                                          orderby m.HowToTake
                                          select m.HowToTake;
            var coffe = from m in _context.Coffe
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                coffe = coffe.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(CoffeHTT))
            {
                coffe = coffe.Where(x => x.HowToTake == CoffeHTT);
            }
            var CoffeHTTVM = new CoffeHowToTakeViewModel
            {
                HowToTakes = new SelectList(await HTTQuery.Distinct().ToListAsync()),
                Coffes = await coffe.ToListAsync()
            };
            return View(CoffeHTTVM);
        }


        // GET: Coffe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffe == null)
            {
                return NotFound();
            }

            return View(coffe);
        }

        // GET: Coffe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coffe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Intensity,Aroma,Type,HowToTake")] Coffe coffe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffe);
        }

        // GET: Coffe/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe.FindAsync(id);
            if (coffe == null)
            {
                return NotFound();
            }
            return View(coffe);
        }

        // POST: Coffe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Intensity,Aroma,Type,HowToTake,Price")] Coffe coffe)
        {
            if (id != coffe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeExists(coffe.Id))
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
            return View(coffe);
        }

        // GET: Coffe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffe == null)
            {
                return NotFound();
            }

            return View(coffe);
        }

        // POST: Coffe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffe = await _context.Coffe.FindAsync(id);
            _context.Coffe.Remove(coffe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeExists(int id)
        {
            return _context.Coffe.Any(e => e.Id == id);
        }
    }
}
