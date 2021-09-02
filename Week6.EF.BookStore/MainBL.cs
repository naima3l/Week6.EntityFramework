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
        private IShelfRepository _shelfRepo;
        public MainBL(IBookRepository bookRepository, IShelfRepository shelfRepository)
        {
            _bookRepo = bookRepository;
            _shelfRepo = shelfRepository;
        }

        public List<Book> FetchBooks()
        {
            return _bookRepo.Fetch();
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _bookRepo.GetByIsbn(isbn);
        }

        public void AddNewBook(string isbn, string author, string title, int quantity, Shelf shelf)
        {
            var newBook = new Book { ISBN = isbn, Author = author, Quantity = quantity, Title = title, ShelfId = shelf.Id};
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

        internal List<Shelf> FetchShelves()
        {
            return _shelfRepo.Fetch();
        }

        internal Shelf GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException();

            var shelf = _shelfRepo.GetByCode(code);
            return shelf;
        }

        internal List<Book> FetchBooksByShelf(Shelf shelf)
        {
            return _bookRepo.FetchBooksByShelf(shelf);
        }
    }
}
