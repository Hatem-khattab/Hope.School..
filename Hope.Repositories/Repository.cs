using Hope.DomainEntites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private DbSet<TEntity> _dbSet;
        private readonly HopeSchoolContext _context;

        public Repository()
        {
            _context = new HopeSchoolContext();
            _dbSet = _context.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Empty entity");
            }

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Empty entity");

            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Update(entity);
            _context.SaveChanges();

            return true;
        }

        public TEntity GetById(int id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("The database context is not initialized.");
            }


            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();

        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
        
            foreach(var item in includes)
            {
                query = query.Include(item);


            }
            return query.Where(expression);    
                    
        }






    }
}
