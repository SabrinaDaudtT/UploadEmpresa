using DAL_.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_.Context;

namespace DAL_.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(Base dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Null DbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {

                entity = DbSet.Add(entity);
                DbContext.SaveChanges();
                return entity;
            }
            return null;
        }

        public virtual IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            IEnumerable<T> ret;
            ret = DbSet.AddRange(entities);
            DbContext.SaveChanges();
            return ret;
        }

        public virtual int Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            try
            {
                return DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
    }
}
