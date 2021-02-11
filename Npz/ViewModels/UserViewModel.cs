using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Npz.ViewModels
{
    public class UserViewModel
    {
        public string SearchName { get; set; }
        public List<UserModel> UserModelList { get; set; }

    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
