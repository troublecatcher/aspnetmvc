using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
	public class OrdersInfo
	{
        [Key]
        public int ID { get; set; }
        
        public int OrderID { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }
        
        public int Quantity { get; set; }

        public int SubTotal { get; set; }
    }
}

