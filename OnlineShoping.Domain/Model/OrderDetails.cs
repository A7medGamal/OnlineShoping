using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Model
{
    public class OrderDetails
    {
        public int Id { get; set; }
        
        [ForeignKey("Orders")]
        public int? OrderId { get; set; }
        public Orders Orders { get; set; }

        [ForeignKey("Items")]
        public int? ItemId { get; set; }
        public Items Items { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
