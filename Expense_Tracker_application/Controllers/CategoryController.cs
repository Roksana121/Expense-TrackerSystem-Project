using Expense_Tracker_application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ExpenseDbContext db = null;
        public CategoryController(ExpenseDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var c = db.Categories.FirstOrDefault(x => x.CategoryId == id);

            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)

            {
                db.Categories.Find(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        
                return View(category);
            }
            
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var ca = db.Categories.FirstOrDefault(x => x.CategoryId == id);
                db.Categories.Remove(ca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
