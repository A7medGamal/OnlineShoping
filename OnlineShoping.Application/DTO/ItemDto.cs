using OnlineShoping.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int? UomId { get; set; }
        //public UOM UOM { get; set; }
        public int QTY { get; set; }
        public int Price { get; set; }
    }
}
