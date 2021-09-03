using System;
using Week6.EF.GestioneSpese.Client;

namespace Week6.EF.GestioneSpese
{
    class Program
    {
        //Realizzare un sistema di gestione delle spese che si basi su:



        //• Un database GestioneSpese(SQL Server), costituito dalle tabelle



        //o Spese
        // Id(int, PK, auto - incrementante)
        // Data(datetime)
        // Descrizione(varchar(500))
        // Utente(varchar(100))
        // Importo(decimal)
        // Approvato(bit)



        //o Categorie
        // Id(int, PK, auto - incrementale)
        // Nome(varchar(100))



        //• Una Console app che consenta di:
        //o Inserire nuove Spese (nell'inserimento, Approvato = false)
        //o Approvare le Spese esistenti(modificare il campo Approvato su 'true')
        //o Cancellare TUTTE le Spese esistenti (... range)
        //o Mostri
        // l'elenco delle Spese Approvate
        // L'elenco delle Spese di uno specifico Utente (opzionale)
        // Il totale delle Spese per Categoria (opzionale)



        //Una spesa è di una certa categoria.
        //Una categoria può avere più spese.



        //VINCOLI TECNICI



        //• Utilizzare Entity Framework Core
        //• Utilizzare l'approccio Code-First e usare le Migrations
        static void Main(string[] args)
        {
            Menu.Start();
        }
    }
}
