using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    [Table("orderdetails")]
    public class OrderDetails
    {
		[Key]
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int UnitPrice { get; set; }
		public int Quantity { get; set; }
		public int Discount { get; set; }
        public int ProductId { get; set; }

		public Product Product { get; set; }
		public Order Order { get; set; }
    }
}
