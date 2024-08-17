using Core.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext
    {
        public readonly TContext _context;

        public EFEntityRepositoryBase(TContext context)
        {
            this._context = context;
        }

        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            addedEntity.State = EntityState.Detached;
        }

        public void Delete(TEntity entity)
        {

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
            deletedEntity.State = EntityState.Detached;

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _context.Set<TEntity>().AsNoTracking().ToList() : _context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return _context.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);

        }

        public void Update(TEntity entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
            updatedEntity.State = EntityState.Detached;
        }

    }

}
