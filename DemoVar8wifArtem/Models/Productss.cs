using System;
using System.Collections.Generic;

namespace DemoVar8wifArtem.Models
{
    public partial class Productss
    {
        public Productss()
        {
            ProductSales = new HashSet<ProductSale>();
        }

        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int? ProductTypeId { get; set; }
        public int? Article { get; set; }
        public int? PeopleForMade { get; set; }
        public int? FactoryNumber { get; set; }
        public int? MinAgentCost { get; set; }

        public virtual ProductType? ProductType { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
