﻿using Microsoft.EntityFrameworkCore;
using PaymentPortal.Data.Interfaces;
using System.Linq.Expressions;

namespace PaymentPortal.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly PaymentsDbContext context;

        public BaseRepository(PaymentsDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var response = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var query = context.Set<T>().Where(predicate);
            return await query.ToListAsync();
        }
    }
}
