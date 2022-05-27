using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
	public class Login
	{
        [Required(ErrorMessage = "Введите email")]
        [DisplayName("Email")]
        [DataType(DataType.PhoneNumber)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

