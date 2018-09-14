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
    public class tasksController : Controller
    {
        private readonly RSMContext _context;

        public tasksController(RSMContext context)
        {
            _context = context;
        }

        // GET: tasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.task.ToListAsync());
        }

        // GET: tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.task
                .SingleOrDefaultAsync(m => m.task_ID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("task_ID,task_name,task_instructions,task_createdate,task_prioritystatus,task_completionstatus,task_duedate")] task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.task.SingleOrDefaultAsync(m => m.task_ID == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("task_ID,task_name,task_instructions,task_createdate,task_prioritystatus,task_completionstatus,task_duedate")] task task)
        {
            if (id != task.task_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!taskExists(task.task_ID))
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
            return View(task);
        }

        // GET: tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.task
                .SingleOrDefaultAsync(m => m.task_ID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.task.SingleOrDefaultAsync(m => m.task_ID == id);
            _context.task.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool taskExists(int id)
        {
            return _context.task.Any(e => e.task_ID == id);
        }
    }
}
