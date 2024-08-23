using Microsoft.EntityFrameworkCore;
using RevisionLinqToEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepositorySQL<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SchoolContext _dbContext;

        public BaseRepositorySQL(SchoolContext dbcontext) { 
            _dbContext = dbcontext;
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            SaveChanges();
        }

        public bool Save(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            TEntity ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            SaveChanges();
            return false;
        }

        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        protected void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.InnerException.Message);
            }
        }
        }
    }

}
