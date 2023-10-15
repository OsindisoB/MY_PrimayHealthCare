using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class CounsellingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CounsellingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Counsellings
        public async Task<IActionResult> Index()
        {
            return _context.CounsellingAppointments != null ?
                        View(await _context.CounsellingAppointments.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.CounsellingAppointments'  is null.");
        }

        [Authorize(Roles = "Counsellor")]
        public async Task<IActionResult> IndexCounsellor()
        {
            return _context.CounsellingAppointments != null ?
                        View(await _context.CounsellingAppointments.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.CounsellingAppointments'  is null.");
        }

        // GET: Counsellings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CounsellingAppointments == null)
            {
                return NotFound();
            }

            var counselling = await _context.CounsellingAppointments
                .FirstOrDefaultAsync(m => m.CounsellingId == id);
            if (counselling == null)
            {
                return NotFound();
            }

            return View(counselling);
        }

        // GET: Counsellings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Counsellings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CounsellingId,CounsellingType,Name,Email,AppointmentDate,AppointmentTime,CounsellorName")] Counselling counselling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(counselling);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = counselling.CounsellingId });
            }
            return View(counselling);
        }

        // GET: Counsellings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CounsellingAppointments == null)
            {
                return NotFound();
            }

            var counselling = await _context.CounsellingAppointments.FindAsync(id);
            if (counselling == null)
            {
                return NotFound();
            }
            return View(counselling);
        }

        // POST: Counsellings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CounsellingId,CounsellingType,Name,Email,AppointmentDate,AppointmentTime,CounsellorName")] Counselling counselling)
        {
            if (id != counselling.CounsellingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counselling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CounsellingExists(counselling.CounsellingId))
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
            return View(counselling);
        }

        // GET: Counsellings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CounsellingAppointments == null)
            {
                return NotFound();
            }

            var counselling = await _context.CounsellingAppointments
                .FirstOrDefaultAsync(m => m.CounsellingId == id);
            if (counselling == null)
            {
                return NotFound();
            }

            return View(counselling);
        }

        // POST: Counsellings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CounsellingAppointments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CounsellingAppointments'  is null.");
            }
            var counselling = await _context.CounsellingAppointments.FindAsync(id);
            if (counselling != null)
            {
                _context.CounsellingAppointments.Remove(counselling);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CounsellingExists(int id)
        {
            return (_context.CounsellingAppointments?.Any(e => e.CounsellingId == id)).GetValueOrDefault();
        }

        public IActionResult Types()
        {
            return View();
        }
    }

}
