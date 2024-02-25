using OnlineShoping.Domain.Model;
using OnlineShoping.Infrastructure.Data;
using OnlineShoping.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Infrastructure.Repository
{
    public class CustomerRepository: Repository<Customers>,ICustomerRepository
    {
        private readonly OnlineShopingDbContext _db;
        public CustomerRepository(OnlineShopingDbContext db) : base(db)
        {
            this._db = db;
        }
    }
}
