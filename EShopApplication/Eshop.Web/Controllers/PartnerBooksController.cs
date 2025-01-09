using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Domain.Domain;
using EShop.Repository;

namespace Eshop.Web.Controllers
{
    public class PartnerBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartnerBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PartnerBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartnerBooks.ToListAsync());
        }

        // GET: PartnerBooks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerBook = await _context.PartnerBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerBook == null)
            {
                return NotFound();
            }

            return View(partnerBook);
        }

        // GET: PartnerBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartnerBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("isbn,title,description,imageURL,totalPages,rating,price,author,publisher,Id")] PartnerBook partnerBook)
        {
            if (ModelState.IsValid)
            {
                partnerBook.Id = Guid.NewGuid();
                _context.Add(partnerBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnerBook);
        }

        // GET: PartnerBooks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerBook = await _context.PartnerBooks.FindAsync(id);
            if (partnerBook == null)
            {
                return NotFound();
            }
            return View(partnerBook);
        }

        // POST: PartnerBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("isbn,title,description,imageURL,totalPages,rating,price,author,AuthorId,publisher,PublisherId,Id")] PartnerBook partnerBook)
        {
            if (id != partnerBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partnerBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerBookExists(partnerBook.Id))
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
            return View(partnerBook);
        }

        // GET: PartnerBooks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerBook = await _context.PartnerBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerBook == null)
            {
                return NotFound();
            }

            return View(partnerBook);
        }

        // POST: PartnerBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var partnerBook = await _context.PartnerBooks.FindAsync(id);
            if (partnerBook != null)
            {
                _context.PartnerBooks.Remove(partnerBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerBookExists(Guid id)
        {
            return _context.PartnerBooks.Any(e => e.Id == id);
        }
    }
}
