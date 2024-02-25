using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Model
{
    public class Customers
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
    }
}
