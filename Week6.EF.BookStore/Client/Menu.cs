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
        private static MainBL mainBL = new MainBL(new EFBookRepository());

        internal static void Start()
        {
            int choice;
            bool check = true;
            do
            {
                Console.WriteLine("Benvenuto!");

                Console.WriteLine("Premi 1 per aggiungere un libro \nPremi 2 per eliminare un libro \nPremi 3 per visualizzare tutti i libri in magazzino \nPremi 4 per aggiornare la quantità di un libro in magazzino \nPremi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
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
                    case 0:
                        check = false;
                        return;
                }
            } while (check);
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

                //inserisco il libro
                mainBL.AddNewBook(isbn, author, title, quantity);
            }
            else
            {
                Console.WriteLine("Esiste già un libro con questo codice isbn");
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
