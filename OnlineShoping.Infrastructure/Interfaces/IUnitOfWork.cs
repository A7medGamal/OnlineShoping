using OnlineShoping.Infrastructure.Interfaces;
using OnlineShoping.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.Interfaces
{
    public interface IUnitOfWork
    {
        void CommitTransaction();
        void Rollback();
         void BeginTransaction();
        public IItemRepository ItemRepository{ get; }
        public ICustomerRepository IcustomerRepository { get; }
        int Save();
    }
}
