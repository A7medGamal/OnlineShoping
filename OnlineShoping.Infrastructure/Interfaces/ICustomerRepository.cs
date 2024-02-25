using OnlineShoping.Application.Interfaces;
using OnlineShoping.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Infrastructure.Interfaces
{
    public interface ICustomerRepository : IRepository<Customers>
    {
    }
}
