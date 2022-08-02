using System;
using System.Linq;

namespace Proxy
{
    class BookStore : IBook
    {
        PageContext db;

        public BookStore()
        {
            db = new PageContext();
        }
        public Page GetPage(int number)
        {
            Console.WriteLine("Connect to DB - BookStore");
            return db.Database.FirstOrDefault(p => p.Number == number);
        }
    }
}
