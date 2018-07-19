using System.Linq;
using System.Collections.Generic;

namespace YouShallNotPass
{
    class Repository<T> : IRepository<T> where T : RepositoryItem
    {

        List<T> DataBase;

        public Repository()
        {
            DataBase = new List<T>();
        }

        public Repository(int capacity)
        {
            DataBase = new List<T>(capacity);
        }

        public void AddItem(T item)
        {
            DataBase.Add(item);
        }

        public void DeleteItem(T item)
        {
            DataBase.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return DataBase;
        }

        public T GetByID(int id)
        {
            return DataBase.FirstOrDefault(p => p.Id == id);

        }

        public T GetItem(T item)
        {
            return DataBase.FirstOrDefault(p => p == item);
        }

        public void UpdateItem(T item)
        {
            DataBase.Remove(item);
            DataBase.Add(item);
        }

        public void AddRange(IEnumerable<T> range)
        {
            DataBase.AddRange(range);
        }
    }
}
