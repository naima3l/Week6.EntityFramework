using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.BookStore.Core.Interfaces;
using Week6.EF.BookStore.Core.Models;

namespace Week6.EF.BookStore.EntityFramework.Repositories
{
    class EFBookRepository : IBookRepository
    {
        private readonly BookContext bookCtx;

        //costruttore che, quando invocato, associa un'istanza di BookContext
        public EFBookRepository()
        {
            bookCtx = new BookContext();
        }


        public void Add(Book item)
        {
            //var newBook = new Book { ISBN = item.ISBN , Author = item.Author, Quantity = 1, Title = item.Title};

            bookCtx.Books.Add(item);
            bookCtx.SaveChanges();
        }

        public void Delete(Book item)
        {
            bookCtx.Books.Remove(item);
            bookCtx.SaveChanges();
        }

        public List<Book> Fetch()
        {
            var books = bookCtx.Books.ToList();
            return books;
        }

        public Book GetById(int id)
        {
            var book = bookCtx.Books.Find(id);
            return book;
        }

        public void UpdateQuantity(Book item, int quantity)
        {
            var book = bookCtx.Books.FirstOrDefault(b => b.ISBN == item.ISBN);

            book.Quantity = quantity;

            bookCtx.SaveChanges();
        }

        public Book GetByIsbn(string isbn)
        {
            var book = bookCtx.Books.FirstOrDefault(b => b.ISBN == isbn);
            return book;
        }

        public void Update(Book b)
        {
            throw new NotImplementedException();
        }
    }
}
