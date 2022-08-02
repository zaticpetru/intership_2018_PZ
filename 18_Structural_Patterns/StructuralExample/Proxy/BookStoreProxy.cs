using System.Collections.Generic;

namespace Proxy
{
    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore bookStore;
        public BookStoreProxy()
        {
            pages = new List<Page>();
        }

        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p => p.Number == number);
            if(page == null)
            {
                if (bookStore == null)
                    bookStore = new BookStore();
                page = bookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }
    }
}
