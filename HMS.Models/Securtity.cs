using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
