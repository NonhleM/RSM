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
    public class teamsController : Controller
    {
        private readonly RSMContext _context;

        public teamsController(RSMContext context)
        {
            _context = context;
        }

        // GET: teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.team.ToListAsync());
        }

        // GET: teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.team
                .SingleOrDefaultAsync(m => m.team_ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("team_ID,team_name,team_datecreated")] team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.team.SingleOrDefaultAsync(m => m.team_ID == id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("team_ID,team_name,team_datecreated")] team team)
        {
            if (id != team.team_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!teamExists(team.team_ID))
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
            return View(team);
        }

        // GET: teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.team
                .SingleOrDefaultAsync(m => m.team_ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.team.SingleOrDefaultAsync(m => m.team_ID == id);
            _context.team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool teamExists(int id)
        {
            return _context.team.Any(e => e.team_ID == id);
        }
    }
}
