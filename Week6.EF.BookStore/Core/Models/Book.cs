using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EF.BookStore.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }

        public Shelf Shelf { get; set; }
        //foreign key
        public int ShelfId { get; set; }

        public string Print()
        {
            return $"Codice ISBN : {ISBN}, Titolo : {Title}, Autore : {Author}, Quantità : {Quantity}, Scaffale : {Shelf.Code}";
        }
    }
}
