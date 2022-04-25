using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Count { get; set; }
        public DateTime CratedAt { get; set; } = DateTime.UtcNow.AddHours(4);
        public string AboutProduct { get; set; }

    }
}
