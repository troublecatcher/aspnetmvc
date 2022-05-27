using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int Total { get; set; }
    }
}
