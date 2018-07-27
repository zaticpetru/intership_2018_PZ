using System;
using System.Linq;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new BookStoreProxy();

            Page page = book.GetPage(1);
            Console.WriteLine(page.Text);

            page = book.GetPage(2);
            Console.WriteLine(page.Text);

            page = book.GetPage(1);
            Console.WriteLine(page.Text);

            page = book.GetPage(4);
            Console.WriteLine(page.Text);

            page = book.GetPage(5);
            Console.WriteLine(page.Text);

            page = book.GetPage(4);
            Console.WriteLine(page.Text);

            page = book.GetPage(2);
            Console.WriteLine(page.Text);

            page = book.GetPage(1);
            Console.WriteLine(page.Text);

            Console.ReadKey();
        }
    }
}
