using CoworkingSpaceSystem.DAL.Context;
using CoworkingSpaceSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingSpaceSystem.DAL.Repositories.Implementations
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

       // private IGenericRepository<T> _genericRepositoryImplementation;
       public GenericRepository(ApplicationDbContext context)
       {
           _context = context;
           _dbSet = _context.Set<T>();
       }

       public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


       public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);


       public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
       public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
       {
           return await _dbSet.Where(predicate).ToListAsync();
       }


       public void Update(T entity) => _dbSet.Update(entity);


       public void Delete(T entity) => _dbSet.Remove(entity);

    }
}
