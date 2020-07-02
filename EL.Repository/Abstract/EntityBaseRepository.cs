using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EL.Domain.Entities;
using System.Threading.Tasks;

namespace EL.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IBaseEntity, new()
    {

        private readonly ELContext _context;

        #region Properties
        public EntityBaseRepository(ELContext context)
        {
            _context = context;
        }
        #endregion
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return  await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual int Count()
        {
            return _context.Set<T>().AsNoTracking().Count();
        }
        public virtual async Task<IEnumerable<T>> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetSingle(Guid id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }
       

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task< IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return  await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }
        public async Task<T> AddData(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<T> UpdateData(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(entity).Property("ModifiedOn").CurrentValue = DateTime.Now;
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property("CreatedOn").IsModified = false;
            await  _context.SaveChangesAsync();
            return entity;



        }

        public virtual async void  Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();
        }

        public virtual async void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public virtual async void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
           await _context.SaveChangesAsync();
        }

        public virtual async void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            await _context.SaveChangesAsync();
        }

        public virtual async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
