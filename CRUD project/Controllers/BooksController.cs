using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_project.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_project.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        // GET: books/create
        public IActionResult Create()
        {
            return View();
        }

        //POST: books/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _db.Dispose();
            }
        }
    }
}

