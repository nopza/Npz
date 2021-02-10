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
    }
}
