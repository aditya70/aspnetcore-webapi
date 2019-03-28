using DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.RepositoryBase
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class 
    {
        protected NorthwindTraderDbContext NorthwindTraderDbContext { get; set; }

        public RepositoryBase(NorthwindTraderDbContext northwindTraderDbContext)
        {
            this.NorthwindTraderDbContext = northwindTraderDbContext;
        }

        public void Create(T entity)
        {
            this.NorthwindTraderDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.NorthwindTraderDbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this.NorthwindTraderDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.NorthwindTraderDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public void Save()
        {
            this.NorthwindTraderDbContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await this.NorthwindTraderDbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            this.NorthwindTraderDbContext.Set<T>().Update(entity);
        }
    }

}
