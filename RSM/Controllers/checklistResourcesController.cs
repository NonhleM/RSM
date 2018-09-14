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
    public class checklistResourcesController : Controller
    {
        private readonly RSMContext _context;

        public checklistResourcesController(RSMContext context)
        {
            _context = context;
        }

        // GET: checklistResources
        public async Task<IActionResult> Index()
        {
            return View(await _context.checklistResource.ToListAsync());
        }

        // GET: checklistResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklistResource = await _context.checklistResource
                .SingleOrDefaultAsync(m => m.checklistresource_ID == id);
            if (checklistResource == null)
            {
                return NotFound();
            }

            return View(checklistResource);
        }

        // GET: checklistResources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: checklistResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("checklistresource_ID")] checklistResource checklistResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checklistResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checklistResource);
        }

        // GET: checklistResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklistResource = await _context.checklistResource.SingleOrDefaultAsync(m => m.checklistresource_ID == id);
            if (checklistResource == null)
            {
                return NotFound();
            }
            return View(checklistResource);
        }

        // POST: checklistResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("checklistresource_ID")] checklistResource checklistResource)
        {
            if (id != checklistResource.checklistresource_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checklistResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!checklistResourceExists(checklistResource.checklistresource_ID))
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
            return View(checklistResource);
        }

        // GET: checklistResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklistResource = await _context.checklistResource
                .SingleOrDefaultAsync(m => m.checklistresource_ID == id);
            if (checklistResource == null)
            {
                return NotFound();
            }

            return View(checklistResource);
        }

        // POST: checklistResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checklistResource = await _context.checklistResource.SingleOrDefaultAsync(m => m.checklistresource_ID == id);
            _context.checklistResource.Remove(checklistResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool checklistResourceExists(int id)
        {
            return _context.checklistResource.Any(e => e.checklistresource_ID == id);
        }
    }
}
