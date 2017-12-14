using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Birdwatcher.Models;

namespace Birdwatcher.Controllers
{
    public class BirdsController : Controller
    {
        private readonly BirdwatcherContext _context;

        public BirdsController(BirdwatcherContext context)
        {
            _context = context;
        }

        // GET: Birds
        public async Task<IActionResult> Index(string searchString, string birdRegion, string birdColor)
        {
            var birds = from b in _context.Bird
                select b;

            IQueryable<string> regionQuery = from b in _context.Bird
                orderby b.Region
                select b.Region;

            if (!String.IsNullOrEmpty(searchString)){
                birds = birds.Where(x => x.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(birdRegion)){
                birds = birds.Where(y=>y.Region.Contains(birdRegion) || y.Region == "All");
            }

            if (!String.IsNullOrEmpty(birdColor)){
                birds = birds.Where(z=>z.Color.Contains(birdColor));
            }

            var birdRegionVM = new RegionViewModel();
            birdRegionVM.regions = new SelectList(await regionQuery.Distinct().ToListAsync());
            birdRegionVM.birds = await birds.ToListAsync();

            return View(birdRegionVM);
        }

        // GET: Birds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bird = await _context.Bird
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bird == null)
            {
                return NotFound();
            }

            return View(bird);
        }


        [Authorize]
        // GET: Birds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Birds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Color,Region,ImageLocation")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bird);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bird);
        }

        // GET: Birds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bird = await _context.Bird.SingleOrDefaultAsync(m => m.ID == id);
            if (bird == null)
            {
                return NotFound();
            }
            return View(bird);
        }

        // POST: Birds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Color,Region,ImageLocation")] Bird bird)
        {
            if (id != bird.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bird);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirdExists(bird.ID))
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
            return View(bird);
        }

        // GET: Birds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bird = await _context.Bird
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bird == null)
            {
                return NotFound();
            }

            return View(bird);
        }

        // POST: Birds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bird = await _context.Bird.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bird.Remove(bird);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BirdExists(int id)
        {
            return _context.Bird.Any(e => e.ID == id);
        }
    }
}
