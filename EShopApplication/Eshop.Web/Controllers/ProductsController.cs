﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;
using EShop.Service.Interface;
using EShop.Domain.Domain;
using EShop.Service.Implementation;

namespace Eshop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuthorService _authorService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IPublisherService _publisherService;

        public ProductsController(IProductService productService, IPublisherService publisherService, IAuthorService authorService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _authorService= authorService;
            _shoppingCartService = shoppingCartService;
            _publisherService = publisherService;
        }

        // GET: Products
        public IActionResult Index()
        {

            return View(_productService.GetAllProducts());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetDetailsForProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_authorService.GetAllProducts(), "Id", "AuthorFullName");
            ViewBag.PublisherId = new SelectList(_publisherService.GetAllProducts(), "Id", "PublisherName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,BookName,author,publisher,AuthorId,PublisherId,BookDescription,BookImage,Price,Rating")] Book product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                product.author= _authorService.GetAllProducts().FirstOrDefault(x => x.Id == product.AuthorId).AuthorFullName;
                product.publisher=_publisherService.GetAllProducts().FirstOrDefault(x =>x.Id==product.PublisherId).PublisherName;
                _productService.CreateNewProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult AddToCart(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetDetailsForProduct(id);

            BookInShoppingCart ps = new BookInShoppingCart();

            if (product != null)
            {
                ps.ProductId = product.Id;
            }

            return View(ps);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(BookInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.AddToShoppingConfirmed(model, userId);

            

            return View("Index", _productService.GetAllProducts());
        }


        // GET: Products/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetDetailsForProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,BookName,BookDescription,BookImage,Price,Rating")] Book product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.UpdateExistingProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetDetailsForProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
