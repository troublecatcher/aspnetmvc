using System;
using System.ComponentModel.DataAnnotations;

namespace rsvp.Models
{
	public class Guest
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите своё имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой e-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Вы ввели некорректный e-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите телефон")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите, примите ли вы участие в вечеринке")]
        public bool? WillAttend { get; set; }
    }
}

