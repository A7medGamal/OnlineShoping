using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CloseDate{ get; set; }
        public string Status { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customers Customer{ get; set; }
        public string DiscountPromoCode { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalPrice { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal ForignPrice { get; set; }
    }
}
