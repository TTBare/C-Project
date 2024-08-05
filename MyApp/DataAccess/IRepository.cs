using System.Collections.Generic;

namespace MyApp.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(int id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
