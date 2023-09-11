using System;
using System.ComponentModel.DataAnnotations;

namespace AlMarket.MVC.ViewModels
{
	public class LoginViewModel
	{
        [Required]

        public string UserName { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}

