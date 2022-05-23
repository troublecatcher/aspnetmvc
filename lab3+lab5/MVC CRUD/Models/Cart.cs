using System;
namespace MVC_CRUD.Models
{
	public class Cart
	{
		public int ItemID { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}

