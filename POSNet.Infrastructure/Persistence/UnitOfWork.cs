using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using POSNet.Application.Interfaces;

namespace POSNet.Infrastructure.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private IDbContextTransaction transaction;
        private readonly POSNetDbContext context;

        public UnitOfWork(POSNetDbContext context)
        {
            this.context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (transaction == null)
            {
                transaction = await context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsymc()
        {
            try
            {
                await context.SaveChangesAsync();
                if (transaction != null)
                {
                    await transaction.CommitAsync();
                    transaction = null;
                }

            }
            catch
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync();
                    transaction = null;
                }
                throw;
            }
        }

        public async Task RollbackAsync()
        {
            if (transaction != null)
            {
                await transaction.RollbackAsync();
                transaction = null;
            }
        }



    }
}
