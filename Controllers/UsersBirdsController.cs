using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Birdwatcher.Models;

namespace Birdwatcher.Controllers
{
    public class UsersBirdsController : Controller
    {
        private readonly BirdwatcherContext _context;

        public UsersBirdsController(BirdwatcherContext context)
        {
            _context = context;
        }

        // GET: UsersBirds
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsersBirds.ToListAsync());
        }

        // GET: UsersBirds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersBirds = await _context.UsersBirds
                .SingleOrDefaultAsync(m => m.ID == id);
            if (usersBirds == null)
            {
                return NotFound();
            }

            return View(usersBirds);
        }

        // GET: UsersBirds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsersBirds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Bird,Description,ImageLocation,DateSeen")] UsersBirds usersBirds)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersBirds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usersBirds);
        }

        // GET: UsersBirds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersBirds = await _context.UsersBirds.SingleOrDefaultAsync(m => m.ID == id);
            if (usersBirds == null)
            {
                return NotFound();
            }
            return View(usersBirds);
        }

        // POST: UsersBirds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Bird,Description,ImageLocation,DateSeen")] UsersBirds usersBirds)
        {
            if (id != usersBirds.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersBirds);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersBirdsExists(usersBirds.ID))
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
            return View(usersBirds);
        }

        // GET: UsersBirds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersBirds = await _context.UsersBirds
                .SingleOrDefaultAsync(m => m.ID == id);
            if (usersBirds == null)
            {
                return NotFound();
            }

            return View(usersBirds);
        }

        // POST: UsersBirds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersBirds = await _context.UsersBirds.SingleOrDefaultAsync(m => m.ID == id);
            _context.UsersBirds.Remove(usersBirds);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersBirdsExists(int id)
        {
            return _context.UsersBirds.Any(e => e.ID == id);
        }
    }
}
