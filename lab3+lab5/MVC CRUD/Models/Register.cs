    using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
	public class Register
	{
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        [DisplayName("Отчество")]
        public string Patro { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [DisplayName("Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [DisplayName("Email")]
        [DataType(DataType.PhoneNumber)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль повторно")]
        [DisplayName("Проверка пароля")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпали!")]
        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}

