using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDbPost.Models;

namespace EFGetStarted.AspNetCore.NewDbPost.Controllers
{
    public class LocalsController : Controller
    {
        private readonly BloggingContext _context;

        public LocalsController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Locals
        public async Task<IActionResult> Index()
        {
            var bloggingContext = _context.Locals.Include(l => l.Company);
            return View(await bloggingContext.ToListAsync());
        }

        // GET: Locals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locals
                .Include(l => l.Company)
                .FirstOrDefaultAsync(m => m.LocalId == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Locals/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name");
            return View();
        }

        // POST: Locals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalId,SpaceID,SquareFoot,PricebySF,MonthlyPayment,AnnualPayment,Deposit,BussinesName,ContractStart,ContractEnd,NameOwner,Email,CompanyId")] Local local)
        {
            //New obj cal annual Payment
            Local newLocal = new Local()
            {
                LocalId = local.LocalId,
                SpaceID=local.SpaceID,
                SquareFoot=local.SquareFoot,
                PricebySF=local.PricebySF,
                MonthlyPayment=local.MonthlyPayment,
                AnnualPayment=local.MonthlyPayment*12,
                Deposit=local.Deposit,
                BussinesName=local.BussinesName,
                ContractStart=local.ContractStart,
                ContractEnd=local.ContractEnd,
                NameOwner=local.NameOwner,
                Email=local.Email,
                CompanyId=local.CompanyId
            };
            
            if (ModelState.IsValid)
            {
                _context.Add(newLocal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name", local.CompanyId);
            return View(local);
        }

        // GET: Locals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locals.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name", local.CompanyId);
            return View(local);
        }

        // POST: Locals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalId,SpaceID,SquareFoot,PricebySF,MonthlyPayment,AnnualPayment,Deposit,BussinesName,ContractStart,ContractEnd,NameOwner,Email,CompanyId")] Local local)
        {
            if (id != local.LocalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.LocalId))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name", local.CompanyId);
            return View(local);
        }

        // GET: Locals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locals
                .Include(l => l.Company)
                .FirstOrDefaultAsync(m => m.LocalId == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var local = await _context.Locals.FindAsync(id);
            _context.Locals.Remove(local);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int id)
        {
            return _context.Locals.Any(e => e.LocalId == id);
        }

       
    }
}
