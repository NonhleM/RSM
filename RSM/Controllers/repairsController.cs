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
    public class repairsController : Controller
    {
        private readonly RSMContext _context;

        public repairsController(RSMContext context)
        {
            _context = context;
        }

        // GET: repairs
        public async Task<IActionResult> Index()
        {
            return View(await _context.repair.ToListAsync());
        }

        // GET: repairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.repair
                .SingleOrDefaultAsync(m => m.repair_ID == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // GET: repairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: repairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("repair_ID,repair_description,repair_prioritystatus,repair_completionstatus,repair_createddate")] repair repair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repair);
        }

        // GET: repairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.repair.SingleOrDefaultAsync(m => m.repair_ID == id);
            if (repair == null)
            {
                return NotFound();
            }
            return View(repair);
        }

        // POST: repairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("repair_ID,repair_description,repair_prioritystatus,repair_completionstatus,repair_createddate")] repair repair)
        {
            if (id != repair.repair_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!repairExists(repair.repair_ID))
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
            return View(repair);
        }

        // GET: repairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.repair
                .SingleOrDefaultAsync(m => m.repair_ID == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // POST: repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repair = await _context.repair.SingleOrDefaultAsync(m => m.repair_ID == id);
            _context.repair.Remove(repair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool repairExists(int id)
        {
            return _context.repair.Any(e => e.repair_ID == id);
        }
    }
}
