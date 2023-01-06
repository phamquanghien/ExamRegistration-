using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamRegistration.Data;
using ExamRegistration.Models;

namespace ExamRegistration.Controllers
{
    public class SubjectGroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubjectGroup
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubjectGroup.Include(s => s.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubjectGroup/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.SubjectGroup == null)
            {
                return NotFound();
            }

            var subjectGroup = await _context.SubjectGroup
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.SubjectGroupID == id);
            if (subjectGroup == null)
            {
                return NotFound();
            }

            return View(subjectGroup);
        }

        // GET: SubjectGroup/Create
        public IActionResult Create()
        {
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectID", "SubjectName");
            return View();
        }

        // POST: SubjectGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectGroupID,SubjectGroupName,SubjectID")] SubjectGroup subjectGroup)
        {
            if (ModelState.IsValid)
            {
                subjectGroup.SubjectGroupID = Guid.NewGuid();
                _context.Add(subjectGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectID", "SubjectName", subjectGroup.SubjectID);
            return View(subjectGroup);
        }

        // GET: SubjectGroup/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.SubjectGroup == null)
            {
                return NotFound();
            }

            var subjectGroup = await _context.SubjectGroup.FindAsync(id);
            if (subjectGroup == null)
            {
                return NotFound();
            }
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectID", "SubjectName", subjectGroup.SubjectID);
            return View(subjectGroup);
        }

        // POST: SubjectGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SubjectGroupID,SubjectGroupName,SubjectID")] SubjectGroup subjectGroup)
        {
            if (id != subjectGroup.SubjectGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectGroupExists(subjectGroup.SubjectGroupID))
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
            ViewData["SubjectID"] = new SelectList(_context.Set<Subject>(), "SubjectID", "SubjectName", subjectGroup.SubjectID);
            return View(subjectGroup);
        }

        // GET: SubjectGroup/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.SubjectGroup == null)
            {
                return NotFound();
            }

            var subjectGroup = await _context.SubjectGroup
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.SubjectGroupID == id);
            if (subjectGroup == null)
            {
                return NotFound();
            }

            return View(subjectGroup);
        }

        // POST: SubjectGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.SubjectGroup == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SubjectGroup'  is null.");
            }
            var subjectGroup = await _context.SubjectGroup.FindAsync(id);
            if (subjectGroup != null)
            {
                _context.SubjectGroup.Remove(subjectGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectGroupExists(Guid id)
        {
          return (_context.SubjectGroup?.Any(e => e.SubjectGroupID == id)).GetValueOrDefault();
        }
    }
}
