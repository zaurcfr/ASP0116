using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public int StockAmount { get; set; }
        public int CategoryId { get; set; }
    }
}
