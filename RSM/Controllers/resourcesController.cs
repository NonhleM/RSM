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
    public class resourcesController : Controller
    {
        private readonly RSMContext _context;

        public resourcesController(RSMContext context)
        {
            _context = context;
        }

        // GET: resources
        public async Task<IActionResult> Index()
        {
            return View(await _context.resource.ToListAsync());
        }

        // GET: resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.resource
                .SingleOrDefaultAsync(m => m.resource_ID == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: resources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("resource_ID,resource_type,resource_name,resource_description,resource_datebought,resource_datecreated,resource_datelastmodified,resource_conditionstatus,resource_availabilitystatus,resource_bookedfordate")] resource resource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.resource.SingleOrDefaultAsync(m => m.resource_ID == id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("resource_ID,resource_type,resource_name,resource_description,resource_datebought,resource_datecreated,resource_datelastmodified,resource_conditionstatus,resource_availabilitystatus,resource_bookedfordate")] resource resource)
        {
            if (id != resource.resource_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!resourceExists(resource.resource_ID))
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
            return View(resource);
        }

        // GET: resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.resource
                .SingleOrDefaultAsync(m => m.resource_ID == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _context.resource.SingleOrDefaultAsync(m => m.resource_ID == id);
            _context.resource.Remove(resource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool resourceExists(int id)
        {
            return _context.resource.Any(e => e.resource_ID == id);
        }
    }
}
