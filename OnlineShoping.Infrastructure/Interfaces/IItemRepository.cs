using OnlineShoping.Application.Interfaces;
using OnlineShoping.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Infrastructure.Interfaces
{
    public interface IItemRepository : IRepository<Items>
    {
        void Update(Items item);
    }
}
