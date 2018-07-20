using System.Collections.Generic;

namespace YouShallNotPass
{
    interface IRepository<T,U> where T : Entity<U> where U : struct
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        T GetItem(T item);
        void AddItem(T item);
        void DeleteItem(T item);
        void UpdateItem(T item);

        void AddRange(IEnumerable<T> range);
    }
}
