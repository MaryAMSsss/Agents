using DemoVar8wifArtem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar8wifArtem.DataB
{
    static class ProductSaleDB
    {
        public static List<ProductSale> GetProductSale()
        {
            return BaseDB.DBContext.ProductSales.ToList();
        }
    }
}
