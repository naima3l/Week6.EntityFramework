using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.BookStore.Core.Models;
using Week6.EF.BookStore.EntityFramework.Repositories;

namespace Week6.EF.BookStore.Client
{
    public class Menu
    {
        private static MainBL mainBL = new MainBL(new EFBookRepository(), new EFShelfRepository());

        internal static void Start()
        {
            int choice;
            bool check = true;
            do
            {
                Console.WriteLine("Benvenuto!");

                Console.WriteLine("Premi 1 per aggiungere un libro \nPremi 2 per eliminare un libro \nPremi 3 per visualizzare tutti i libri in magazzino \nPremi 4 per aggiornare la quantità di un libro in magazzino \nPremi 5 per visualizzare i libri di uno scaffale \nPremi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        //aggiungi libro
                        AddNewBook();
                        break;
                    case 2:
                        //elimina libro
                        RemoveBookByISBN();
                        break;
                    case 3:
                        //visualizzare tutti i libri
                        ShowBooks();
                        break;
                    case 4:
                        //modificare la quantità
                        UpdateBookQuantity();
                        break;
                    case 5:
                        //visualizzare i libri di uno scaffale
                        ShowBooksOnShelf();
                        break;
                    case 0:
                        check = false;
                        return;
                }
            } while (check);
        }

        private static void ShowBooksOnShelf()
        {
            Shelf shelf;
            //scaffale
            do
            {
                Console.WriteLine("\nInserire il Codice dello scaffale di cui vuoi visualizzare i libri");
                ShowShelves(); //mostra tutti i codici degli scaffali
                string code = Console.ReadLine();

                //Recupero lo scaffale con il codice inserito
                //Se esiste, ok. Altrimenti mi richiede di inserire il codice
                shelf = GetShelfByCode(code);
            } while (shelf == null);

            List<Book> books = mainBL.FetchBooksByShelf(shelf);
            if (books.Count == 0)
            {
                Console.WriteLine($"Non ci sono libri nello scaffale {shelf.Code}");
            }
            else
            {
                foreach(var b in books)
                {
                    Console.WriteLine(b.Print());
                }
            }

        }

        private static void UpdateBookQuantity()
        {

            int i = 1;
            var books = mainBL.FetchBooks();

            bool isInt;
            int bookToUpdate;
            do
            {
                Console.WriteLine("Quale libro vuoi modificare?");

                foreach (var b in books)
                {
                    Console.WriteLine($"Premi {i} per {b.Print()}");
                    i++;
                }

                isInt = int.TryParse(Console.ReadLine(), out bookToUpdate);

            } while (!isInt || bookToUpdate <= 0 || bookToUpdate > books.Count);

            int quantity = 0;

            Console.WriteLine("Inserisci la quantità");
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 1)
            {
                Console.WriteLine("Scelta non valida. Riprova!");
            }

            Book book = books.ElementAt(bookToUpdate - 1);
            mainBL.UpdateBookQuantity(book,quantity);
        }

        private static void RemoveBookByISBN()
        {
            //string isbn;
            //do
            //{
            //    Console.WriteLine("\nInserisci il codice ISBN (10 cifre) del libro che vuoi rimuovere.");
            //    isbn = Console.ReadLine();
            //}
            //while (isbn.Length != 10);

            //Book book = mainBL.GetBookByIsbn(isbn);
            //if (mainBL.GetBookByIsbn(isbn) == null)
            //{
            //    Console.WriteLine("\nIl libro che stai cercando di rimuovere non esiste.");
            //}
            //else
            //{
            //    mainBL.RemoveBook(book);
            //}

            int i = 1;
            var books = mainBL.FetchBooks();

            bool isInt;
            int bookToDelete;
            do
            {
                Console.WriteLine("Quale libro vuoi modificare?");

                foreach (var b in books)
                {
                    Console.WriteLine($"Premi {i} per {b.Print()}");
                    i++;
                }

                isInt = int.TryParse(Console.ReadLine(), out bookToDelete);

            } while (!isInt || bookToDelete <= 0 || bookToDelete > books.Count);

            Book book = books.ElementAt(bookToDelete - 1);
            mainBL.RemoveBook(book);
        }

        private static void AddNewBook()
        {
            string isbn, title, author;
            int quantity = 1;
            do
            {
                Console.WriteLine("\nInserisci il codice ISBN (10 cifre)");
                isbn = Console.ReadLine();
            }
            while (isbn.Length != 10);

            //se esiste già un libro con lo stesso codice, lo segnala, se no si procede all'inserimento
            if (mainBL.GetBookByIsbn(isbn) == null)
            {
                //inserire titolo
                do
                {
                    Console.WriteLine("\nInserire il titolo del libro");
                    title = Console.ReadLine();
                } while (title.Length == 0);

                //inserire autore
                do
                {
                    Console.WriteLine("\nInserire l'autore del libro");
                    author = Console.ReadLine();
                } while (author.Length == 0);

                Shelf shelf;
                //scaffale
                do
                {
                    Console.WriteLine("\nInserire il Codice dello scaffale in cui posizionare il libro");
                    ShowShelves(); //mostra tutti i codici degli scaffali
                    string code = Console.ReadLine();

                    //Recupero lo scaffale con il codice inserito
                    //Se esiste, ok. Altrimenti mi richiede di inserire il codice
                    shelf = GetShelfByCode(code);
                } while (shelf == null);

                //inserisco il libro
                mainBL.AddNewBook(isbn, author, title, quantity,shelf);
            }
            else
            {
                Console.WriteLine("Esiste già un libro con questo codice isbn");
            }
        }

        private static Shelf GetShelfByCode(string code)
        {
            var shelf = mainBL.GetByCode(code);
            return shelf;
        }

        private static void ShowShelves()
        {
            //recupera dati degli scaffali dal db
            var shelves = mainBL.FetchShelves();

            //stampa i dati
            if(shelves.Count != 0)
            {
                Console.WriteLine("Scaffali: ");
                foreach(var s in shelves)
                {
                    Console.WriteLine(s.Code);
                }
            }
            else
            {
                Console.WriteLine("Non ci sono scaffali");
            }
        }

        public  static void ShowBooks()
        {
            var books = mainBL.FetchBooks();

            if(books == null)
            {
                Console.WriteLine("Non ci sono libri.");
            }
            else
            {
                foreach(var b in books)
                {
                    Console.WriteLine("\n" +b.Print());
                }
            }
        }
    }
}
