using System;
using System.Collections.Generic;

namespace DemoVar8wifArtem.Models
{
    public partial class ProductSale
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? AgentId { get; set; }
        public DateTime? Date { get; set; }
        public int? CountOfProduct { get; set; }

        public virtual Agent? Agent { get; set; }
        public virtual Productss? Product { get; set; }
    }
}
