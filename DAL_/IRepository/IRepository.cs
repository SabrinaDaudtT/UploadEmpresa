using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_.IRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        T Add(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entity);

        int Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Remove(int id);

        int SaveChanges();
    }
}
