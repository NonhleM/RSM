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
    public class teamLeadersController : Controller
    {
        private readonly RSMContext _context;

        public teamLeadersController(RSMContext context)
        {
            _context = context;
        }

        // GET: teamLeaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.teamLeader.ToListAsync());
        }

        // GET: teamLeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeader = await _context.teamLeader
                .SingleOrDefaultAsync(m => m.teamleader_ID == id);
            if (teamLeader == null)
            {
                return NotFound();
            }

            return View(teamLeader);
        }

        // GET: teamLeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: teamLeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("teamleader_ID")] teamLeader teamLeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamLeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamLeader);
        }

        // GET: teamLeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeader = await _context.teamLeader.SingleOrDefaultAsync(m => m.teamleader_ID == id);
            if (teamLeader == null)
            {
                return NotFound();
            }
            return View(teamLeader);
        }

        // POST: teamLeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("teamleader_ID")] teamLeader teamLeader)
        {
            if (id != teamLeader.teamleader_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamLeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!teamLeaderExists(teamLeader.teamleader_ID))
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
            return View(teamLeader);
        }

        // GET: teamLeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeader = await _context.teamLeader
                .SingleOrDefaultAsync(m => m.teamleader_ID == id);
            if (teamLeader == null)
            {
                return NotFound();
            }

            return View(teamLeader);
        }

        // POST: teamLeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamLeader = await _context.teamLeader.SingleOrDefaultAsync(m => m.teamleader_ID == id);
            _context.teamLeader.Remove(teamLeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool teamLeaderExists(int id)
        {
            return _context.teamLeader.Any(e => e.teamleader_ID == id);
        }
    }
}
