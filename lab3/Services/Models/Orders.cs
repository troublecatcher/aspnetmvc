using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Необходимо указать заказчика")]
        [DisplayName("ID заказчика")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Необходимо указать название")]
        [DisplayName("Название")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Необходимо указать цену")]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Необходимо указать количество")]
        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [DisplayName("Описание")]
        public string Remarks { get; set; }
    }
}
