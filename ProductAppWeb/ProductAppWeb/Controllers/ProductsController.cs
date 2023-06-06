using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductAppWeb.Data;
using ProductAppWeb.Models;

namespace ProductAppWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var result = await _context.Products.ToListAsync();

            result.Sort((p1, p2) =>
            {
                return p1.Price - p2.Price;
            });

            return View(result);
        }

        // GET: Products/Details/Id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,CreatedAt,UpdatedAt")] Product product)
        {
            string? name = product.Name;
            if (_context.Products.Any(p => p.Name == name))
            {
                ModelState.AddModelError("Name", "Product name already in use.");
            }

            bool isOnlyLetters = name.All(Char.IsLetter);
            if (!isOnlyLetters)
            {
                ModelState.AddModelError("Name", "Product name has to use only letters.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Product created successfully.";

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,CreatedAt,UpdatedAt")] Product product)
        {
            var currName = TempData["Name"] as string;
            if (id != product.Id || currName == null)
            {
                return NotFound();
            }

            var name = product.Name;
            if (_context.Products.Any(p => p.Name == name && currName != name))
            {
                ModelState.AddModelError("Name", "Product name already in use.");
            }

            bool isOnlyLetters = name.All(Char.IsLetter);
            if (!isOnlyLetters)
            {
                ModelState.AddModelError("Name", "Product name has to use only letters.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.UpdatedAt = DateTime.Now;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                TempData["Success"] = "Product edited successfully.";

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'DatabaseContext.Products'  is null.");
            }

            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();

            TempData["Success"] = "Product deleted successfully.";

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Products.Any(e => e.Id == id);
        }
    }
}
