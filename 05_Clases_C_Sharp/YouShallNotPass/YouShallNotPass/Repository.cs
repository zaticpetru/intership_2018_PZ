using System.Linq;
using System.Collections.Generic;

namespace YouShallNotPass
{
    class Repository<T> : IRepository<T> where T : Entity
    {

        List<T> DataBase;

        public Repository()
        {
            DataBase = new List<T>();
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

        //public T GetItem(T item)
        //{
        //    return DataBase.FirstOrDefault(p => p == item);
        //}

        public void UpdateItem(T item) // to add : update values by ID (int ID, T newItem)
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
