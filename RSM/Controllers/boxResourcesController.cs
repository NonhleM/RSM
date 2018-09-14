using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSM.Models;

namespace RSM.Controllers
{
    public class boxResourcesController : Controller
    {
        private readonly RSMContext _context;

        public boxResourcesController(RSMContext context)
        {
            _context = context;
        }

        // GET: boxResources
        public async Task<IActionResult> Index()
        {
            return View(await _context.boxResource.ToListAsync());
        }

        // GET: boxResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxResource = await _context.boxResource
                .SingleOrDefaultAsync(m => m.boxresource_id == id);
            if (boxResource == null)
            {
                return NotFound();
            }

            return View(boxResource);
        }

        // GET: boxResources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: boxResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("boxresource_id")] boxResource boxResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boxResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boxResource);
        }

        // GET: boxResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxResource = await _context.boxResource.SingleOrDefaultAsync(m => m.boxresource_id == id);
            if (boxResource == null)
            {
                return NotFound();
            }
            return View(boxResource);
        }

        // POST: boxResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("boxresource_id")] boxResource boxResource)
        {
            if (id != boxResource.boxresource_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boxResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!boxResourceExists(boxResource.boxresource_id))
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
            return View(boxResource);
        }

        // GET: boxResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxResource = await _context.boxResource
                .SingleOrDefaultAsync(m => m.boxresource_id == id);
            if (boxResource == null)
            {
                return NotFound();
            }

            return View(boxResource);
        }

        // POST: boxResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boxResource = await _context.boxResource.SingleOrDefaultAsync(m => m.boxresource_id == id);
            _context.boxResource.Remove(boxResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool boxResourceExists(int id)
        {
            return _context.boxResource.Any(e => e.boxresource_id == id);
        }
    }
}
