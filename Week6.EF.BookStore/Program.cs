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
            /*Aggiungiamo l'entità scaffale, che ha come proprietà Id e Codice ( esempio SC01. Deve essere al massimo lungo 6 caratteri). 
             *Lo scaffale può contenere più libri e il libro può stare in un solo scaffale.
             *Aggiunta: Si devono poter visualizzare tutti i libri di uno scaffale.
            */
            Menu.Start();

            //Menu.ShowBooks();
        }
    }
}
