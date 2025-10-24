using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nguyencongthang_231230913_de01.Models;

namespace nguyencongthang_231230913_de01.Controllers
{
    public class nctComputersController : Controller
    {
        private readonly ComputerDbContext _context;

        public nctComputersController(ComputerDbContext context)
        {
            _context = context;
        }

        // GET: nctComputers
        public async Task<IActionResult> nctIndex()
        {
            return View(await _context.nctComputers.ToListAsync());
        }

        // GET: nctComputers/Details/5
        public async Task<IActionResult> nctDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctComputer = await _context.nctComputers
                .FirstOrDefaultAsync(m => m.nctComId == id);
            if (nctComputer == null)
            {
                return NotFound();
            }

            return View(nctComputer);
        }

        // GET: nctComputers/Create
        public IActionResult nctCreate()
        {
            return View();
        }

        // POST: nctComputers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nctCreate([Bind("nctComId,nctComName,nctComPrice,nctComImage,nctComStatus")] nctComputer nctComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nctComputer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(nctIndex));
            }
            return View(nctComputer);
        }

        // GET: nctComputers/Edit/5
        public async Task<IActionResult> nctEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctComputer = await _context.nctComputers.FindAsync(id);
            if (nctComputer == null)
            {
                return NotFound();
            }
            return View(nctComputer);
        }

        // POST: nctComputers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nctEdit(int? id, [Bind("nctComId,nctComName,nctComPrice,nctComImage,nctComStatus")] nctComputer nctComputer)
        {
            if (id != nctComputer.nctComId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nctComputer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nctComputerExists(nctComputer.nctComId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(nctIndex));
            }
            return View(nctComputer);
        }

        // GET: nctComputers/Delete/5
        public async Task<IActionResult> nctDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctComputer = await _context.nctComputers
                .FirstOrDefaultAsync(m => m.nctComId == id);
            if (nctComputer == null)
            {
                return NotFound();
            }

            return View(nctComputer);
        }

        // POST: nctComputers/Delete/5
        [HttpPost, ActionName("nctDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nctDeleteConfirmed(int? id)
        {
            var nctComputer = await _context.nctComputers.FindAsync(id);
            if (nctComputer != null)
            {
                _context.nctComputers.Remove(nctComputer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(nctIndex));
        }

        private bool nctComputerExists(int? id)
        {
            return _context.nctComputers.Any(e => e.nctComId == id);
        }
    }
}
