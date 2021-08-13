using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SchoolApiSrc.Services.IServices;
using System.Threading.Tasks;
using SchoolApiSrc.Data;

namespace SchoolApiSrc.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly SchoolContext _context;
        internal DbSet<T> _db;

        public Service(SchoolContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task CreateA(T identity)
        {
            await _db.AddAsync(identity);
        }

        public async Task<T> Get(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = _db;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = _db;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync();
        }


        public void Remove(T identity)
        {
            _db.Remove(identity);
        }

        public void RemoveById(int id)
        {
            var objectToRemove = _db.Find(id);
            _db.Remove(objectToRemove);
        }

        public void Update(int id)
        {
            var objectToUpdate = _db.Find(id);
            _db.Update(objectToUpdate);
        }
    }
}