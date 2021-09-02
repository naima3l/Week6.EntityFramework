using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.BookStore.Core.Interfaces;
using Week6.EF.BookStore.Core.Models;

namespace Week6.EF.BookStore
{
    public class MainBL //business layer più o meno
    {
        private IBookRepository _bookRepo;
        public MainBL(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public List<Book> FetchBooks()
        {
            return _bookRepo.Fetch();
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _bookRepo.GetByIsbn(isbn);
        }

        public void AddNewBook(string isbn, string author, string title, int quantity)
        {
            var newBook = new Book { ISBN = isbn, Author = author, Quantity = quantity, Title = title };
            if (newBook == null) throw new ArgumentNullException();
            _bookRepo.Add(newBook);
        }

        internal void RemoveBook(Book book)
        {
            _bookRepo.Delete(book);
        }

        internal void UpdateBookQuantity(Book book, int quantity)
        {
            _bookRepo.UpdateQuantity(book,quantity);
        }
    }
}
