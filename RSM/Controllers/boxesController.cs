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
    public class boxesController : Controller
    {
        private readonly RSMContext _context;

        public boxesController(RSMContext context)
        {
            _context = context;
        }

        // GET: boxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.box.ToListAsync());
        }

        // GET: boxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.box
                .SingleOrDefaultAsync(m => m.box_id == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // GET: boxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: boxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("box_id,box_name,box_row,box_column,box_createddate")] box box)
        {
            if (ModelState.IsValid)
            {
                _context.Add(box);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(box);
        }

        // GET: boxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.box.SingleOrDefaultAsync(m => m.box_id == id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);
        }

        // POST: boxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("box_id,box_name,box_row,box_column,box_createddate")] box box)
        {
            if (id != box.box_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(box);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!boxExists(box.box_id))
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
            return View(box);
        }

        // GET: boxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.box
                .SingleOrDefaultAsync(m => m.box_id == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // POST: boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var box = await _context.box.SingleOrDefaultAsync(m => m.box_id == id);
            _context.box.Remove(box);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool boxExists(int id)
        {
            return _context.box.Any(e => e.box_id == id);
        }
    }
}
