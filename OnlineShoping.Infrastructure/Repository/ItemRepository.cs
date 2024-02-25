using Microsoft.AspNetCore.Http.Features;
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
    public class ItemRepository : Repository<Items>  , IItemRepository
    {
        private readonly OnlineShopingDbContext _db;
        public ItemRepository(OnlineShopingDbContext db) :base(db)     
        {
            this._db = db;
        }

        public void Update(Items item)
        {
           _db.Update(item);
        }
    }
}
