
using Microsoft.EntityFrameworkCore.Storage;
using OnlineShoping.Application.Interfaces;
using OnlineShoping.Infrastructure.Data;
using OnlineShoping.Infrastructure.Interfaces;
using OnlineShoping.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopingDbContext context;


       public IItemRepository ItemRepository { get; private set; }
        public ICustomerRepository IcustomerRepository { get; private set; }
        public UnitOfWork(OnlineShopingDbContext context)
        {
            this.context = context;
            ItemRepository = new ItemRepository(context);
            IcustomerRepository=new CustomerRepository(context);
        }
        private IDbContextTransaction transaction;
        public void CommitTransaction()
        {
            try
            {
                if (transaction != null)
                {
                     transaction.Commit();
                    transaction = null; // Reset transaction after committing
                }
            }
            catch
            {
                if (transaction != null)
                {
                     transaction.Rollback();
                    throw; // Re-throw the exception after rolling back
                }
            }
            finally
            {
                // Always dispose the transaction object
                transaction?.DisposeAsync();
            }
        }
        public void  Rollback()
        {
             transaction?.Rollback();
        }
        public  void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
