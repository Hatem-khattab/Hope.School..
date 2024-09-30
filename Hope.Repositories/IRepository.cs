using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Repositories
{
    public interface IRepository <TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        bool Delete (TEntity entity);

        bool Update (TEntity entity);

        IQueryable<TEntity> GetAll ();
        // to search outsude the memory and it is faster 
        
        // IEnumerable<TEntity> FindAll ();
        // the query is to be exucted within the memory only !! 
        TEntity GetById (int id);

       IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
       //a very important method


    }
}
