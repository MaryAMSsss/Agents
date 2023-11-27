using System;
using System.Collections.Generic;

namespace DemoVar8wifArtem.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Productsses = new HashSet<Productss>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Productss> Productsses { get; set; }
    }
}
