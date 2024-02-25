using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Domain.Model
{
    public class UOM
    {
        [Key]
        public int UomId { get; set; }
        public string Uom { get; set; }
        public string Description { get; set; }
    }
}
