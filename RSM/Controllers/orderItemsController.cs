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
    public class orderItemsController : Controller
    {
        private readonly RSMContext _context;

        public orderItemsController(RSMContext context)
        {
            _context = context;
        }

        // GET: orderItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.orderItems.ToListAsync());
        }

        // GET: orderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.orderItems
                .SingleOrDefaultAsync(m => m.orderitem_ID == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // GET: orderItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: orderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orderitem_ID")] orderItems orderItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderItems);
        }

        // GET: orderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.orderItems.SingleOrDefaultAsync(m => m.orderitem_ID == id);
            if (orderItems == null)
            {
                return NotFound();
            }
            return View(orderItems);
        }

        // POST: orderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orderitem_ID")] orderItems orderItems)
        {
            if (id != orderItems.orderitem_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!orderItemsExists(orderItems.orderitem_ID))
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
            return View(orderItems);
        }

        // GET: orderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.orderItems
                .SingleOrDefaultAsync(m => m.orderitem_ID == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // POST: orderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItems = await _context.orderItems.SingleOrDefaultAsync(m => m.orderitem_ID == id);
            _context.orderItems.Remove(orderItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool orderItemsExists(int id)
        {
            return _context.orderItems.Any(e => e.orderitem_ID == id);
        }
    }
}
