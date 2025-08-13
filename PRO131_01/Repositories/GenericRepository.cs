using Microsoft.EntityFrameworkCore;
using PRO131_01.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRO131_01.Repositories
{
    public class GenericRepository<T> where T : class
    {
        readonly public CategoryDbContext _context;
        readonly public DbSet<T> _dbSet;
        public GenericRepository() 
        {
            _context = new CategoryDbContext();
            _dbSet = _context.Set<T>();
        }
        public List<T> GetAll() 
        {
            return _dbSet.ToList();
        }
        public T Get(params object[] keys) 
        {
            return _dbSet.Find(keys);
        }
        public void Add(T item) 
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(T item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }
        public void Remove(T item) 
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public List<T> GetAllWithInclude(params string[] includeProp) 
        {
            var query = _dbSet.AsQueryable();
            foreach (var prop in includeProp)
            {
                query= query.Include(prop);
                
            }
            return query.ToList();
        }
        public List<T> Loc(params Expression<Func<T, bool>>[] predicates)
        {
            var query = _dbSet.AsQueryable();
            foreach (var pre in predicates)
            {
                query = query.Where(pre);
            }

            return query.ToList();
        }

        public List<T> Loc(params string[] predicates)
        {
            var query = _dbSet.AsQueryable();
            foreach (var pre in predicates)
            {
                query = query.Where(pre);
            }

            return query.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }


    }
}
