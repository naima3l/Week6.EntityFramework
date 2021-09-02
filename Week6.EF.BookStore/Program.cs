using System;
using Week6.EF.BookStore.Client;

namespace Week6.EF.BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Gestione del magazzino nella libreria :
             * L'utente magazziniere, all'accesso al sistema, deve poter :
             * -aggiungere un libro
             * -eliminare un libro
             * -visualizzare tutti i libri
             * -aggiornare la quantità di un libro in magazzino
             */
            Menu.Start();

            //Menu.ShowBooks();
        }
    }
}
