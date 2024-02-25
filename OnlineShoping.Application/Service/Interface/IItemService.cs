using OnlineShoping.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.Service.Interface
{
    public interface IItemService
    {

        IEnumerable<ItemDto> GetAllItem();

        ItemDto GetItemById(int id);
        void CreateItem(ItemDto ItemDto);
        void UpdateItem(ItemDto ItemDto, int id);
        bool DeleteItem(int id);
       
    }
}
