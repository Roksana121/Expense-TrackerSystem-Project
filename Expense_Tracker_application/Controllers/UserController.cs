using Expense_Tracker_application.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_application.Controllers
{
    public class UserController : Controller
    {
        private readonly ExpenseDbContext db = null;
        public UserController(ExpenseDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var userInformation = (from u in db.Users
                                   join ca in db.Categories on u.CategoryId equals ca.CategoryId
                                   select new UserVM
                                   {
                                       UserId = u.UserId,
                                       UserName = u.UserName,
                                       CategoryId = ca.CategoryId,
                                       CategoryName = ca.CategoryName,
                                       ExpenseDate = u.ExpenseDate,
                                       Amount = u.Amount
                                   }).ToList();

            return View(userInformation);
        }
        public IActionResult Create()
        {

            ViewBag.categories = db.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(UserVM vm)
        {
            if (ModelState.IsValid)
            {
                User u = new User
                {
                    UserName = vm.UserName,
                    CategoryId = vm.CategoryId,
                    ExpenseDate = vm.ExpenseDate,
                    Amount = vm.Amount
                };
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return BadRequest();
            }

            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id != null)
            {

                var u = db.Users.FirstOrDefault(x => x.UserId == id);

                UserVM vm = new UserVM()
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    CategoryId=u.CategoryId,
                    CategoryName = u.CategoryName,
                    ExpenseDate = u.ExpenseDate,
                    Amount = u.Amount
                };

                ViewBag.categories = db.Categories.ToList();
                return View(vm);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UserVM vm)
        {
            if (ModelState.IsValid)
            {
                User u = new User
                {
                    UserId = vm.UserId,
                    UserName = vm.UserName,
                    CategoryId = vm.CategoryId,
                    CategoryName = vm.CategoryName,
                    ExpenseDate = vm.ExpenseDate,
                    Amount = vm.Amount
                };

                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                User u = new User
                {
                    UserId = vm.UserId,
                    UserName = vm.UserName,
                    CategoryId = vm.CategoryId,
                    CategoryName = vm.CategoryName,
                    ExpenseDate = vm.ExpenseDate,
                    Amount = vm.Amount
                };

                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {

            if (id != null)
            {
                var u = db.Users.FirstOrDefault(x => x.UserId == id);
                UserVM vm = new UserVM()
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    CategoryId = u.CategoryId,
                    CategoryName = u.CategoryName,
                    ExpenseDate = u.ExpenseDate,
                    Amount = u.Amount
                };
                ViewBag.categories = db.Categories.ToList();
                return View(vm);
            }

            return View();

        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.UserId == id);
            db.Entry(user).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
   
}