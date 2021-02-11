using Microsoft.AspNetCore.Mvc;
using Npz.Data;
using Npz.Models;
using Npz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Npz.Controllers
{
    public class RegisterController : Controller
    {
        private ApplicationDbContext _db;

        public RegisterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<User> objectList = _db.User;

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UserModelList = objectList.Select(e => new UserModel
            {
                Id = e.Id,
                Username = e.Username,
                Password = e.Password,
                Name = e.Name,
                Age = e.Age
            }).ToList();

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Search(UserViewModel user)
        {
            IEnumerable<User> objectList = _db.User;

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UserModelList = objectList.Select(e => new UserModel
            {
                Id = e.Id,
                Username = e.Username,
                Password = e.Password,
                Name = e.Name,
                Age = e.Age
            }).ToList();

            var userName = user.SearchName ?? string.Empty;

            user.UserModelList = userViewModel.UserModelList.Where(x => x.Username.Contains(userName, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return View("Index", user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.User.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.User.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.User.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.User.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
