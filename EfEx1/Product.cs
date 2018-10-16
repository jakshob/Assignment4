using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfEx1
{
    [Table("products")]
    public class Product
    {
        [Column("productid")]
        public int Id { get; set; }

        [Column("productname")]
        public string Name { get; set; }
        [Column("categoryid")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
