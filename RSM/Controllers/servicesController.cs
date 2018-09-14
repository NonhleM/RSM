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
    public class servicesController : Controller
    {
        private readonly RSMContext _context;

        public servicesController(RSMContext context)
        {
            _context = context;
        }

        // GET: services
        public async Task<IActionResult> Index()
        {
            return View(await _context.service.ToListAsync());
        }

        // GET: services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.service
                .SingleOrDefaultAsync(m => m.service_id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("service_id,service_name,service_description,service_datetime,service_venue,service_createddate")] service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.service.SingleOrDefaultAsync(m => m.service_id == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("service_id,service_name,service_description,service_datetime,service_venue,service_createddate")] service service)
        {
            if (id != service.service_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!serviceExists(service.service_id))
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
            return View(service);
        }

        // GET: services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.service
                .SingleOrDefaultAsync(m => m.service_id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.service.SingleOrDefaultAsync(m => m.service_id == id);
            _context.service.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool serviceExists(int id)
        {
            return _context.service.Any(e => e.service_id == id);
        }
    }
}
