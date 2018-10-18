using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    [Table("products")]
    public class Product
    {
        [Column("productid")]
        public int Id { get; set; }

        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }

        [Column("productname")]
        public string Name { get; set; }
        [Column("categoryid")]
        public int CategoryId { get; set; }

        //PROBLEM HER!: - Hvordan tilgår man category for at få Name fra ID uden at bruge Metodekald?
        public Category Category { get; set; }
    }
}
