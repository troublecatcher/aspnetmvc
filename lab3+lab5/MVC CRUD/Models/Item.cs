using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUD.Models
{
	public class Item
	{
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Необходимо указать название")]
        [DisplayName("Название")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Необходимо добавить описание")]
        [DisplayName("Описание")]
        public string? Desc { get; set; }

        [Required(ErrorMessage = "Необходимо указать цену")]
        [DisplayName("Цена")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Необходимо указать количество")]
        [DisplayName("Количество")]
        public int Qty { get; set; }

        [DisplayName("Изображение")]
        public string? ImageName { get; set; }

        [NotMapped]
        [DisplayName("Загрузите изображение")]
        public IFormFile? ImageFile { get; set; }
    }
}

