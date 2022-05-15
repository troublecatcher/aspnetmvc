using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Customers
    {
        [Key]
        [DisplayName("ID")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Необходимо указать фамилию")]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Необходимо указать имя")]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо указать отчество")]
        [DisplayName("Отчество")]
        public string Patro { get; set; }

        [DisplayName("Пол")]
        public string Sex { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Необходимо указать адрес")]
        [DisplayName("Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Необходимо указать Email")]
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
