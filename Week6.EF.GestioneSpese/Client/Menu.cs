using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.GestioneSpese.Core.Models;
using Week6.EF.GestioneSpese.EF.Repositories;

namespace Week6.EF.GestioneSpese.Client
{
    public class Menu
    {
        private static MainBL mainBL = new MainBL(new EFShoppingRepository(), new EFCategoryRepository());

        internal static void Start()
        {
            int choice;
            bool check = true;
            do
            {
                Console.WriteLine("Benvenuto!");

                Console.WriteLine("Premi 1 per inserire una nuova spesa \nPremi 2 per approvare una spesa esistente \nPremi 3 cancellare TUTTE le Spese esistenti \nPremi 4 per visualizzare l'elenco delle Spese Approvate \nPremi 5 per visualizzare l'elenco delle Spese di uno specifico Utente \nPremi 6 per visualizzare il totale delle Spese per Categoria di un utente \nPremi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        //aggiungi spesa
                        AddNewShopping();
                        break;
                    case 2:
                        //approva spese esistenti
                        ApproveExistingShopping();
                        break;
                    case 3:
                        //eliminare tutte le spese
                        DeleteAllShopping();
                        break;
                    case 4:
                        //visualizzare spese esistenti
                        ShowApprovedExistingShopping();
                        break;
                    case 5:
                        //visualizzare le spese di un utente
                        ShowUserShopping();
                        break;
                    case 6:
                        //visualizzare le spese di un utente per categoria
                        ShowUserShoppingByCategory();
                        break;
                    case 0:
                        check = false;
                        return;
                }
            } while (check);
        }

        private static void ShowUserShoppingByCategory()
        {
            throw new NotImplementedException();
        }

        private static void ShowUserShopping()
        {
            throw new NotImplementedException();
        }

        private static void ShowApprovedExistingShopping()
        {
            throw new NotImplementedException();
        }

        private static void DeleteAllShopping()
        {
            throw new NotImplementedException();
        }

        private static void ApproveExistingShopping()
        {
            int id;
            Shopping shopping;
            do
            {
                Console.WriteLine("\nInserire l'id della spesa che vuoi approvare");
                int result = ShowNonApprovedExistingShopping(); //mostra tutti i codici degli scaffali
                if(result == 0)
                {
                    break;
                }

                while(!int.TryParse(Console.ReadLine(),out id) || id < 1)
                {
                    Console.WriteLine("Scelta sbagliata!");
                }

                shopping = GetById(id);
                mainBL.Approve(shopping);
            } while (shopping == null);
        }

        private static Shopping GetById(int id)
        {
            Shopping s = mainBL.GetById(id);
            return s;
        }

        private static int ShowNonApprovedExistingShopping()
        {
            List<Shopping> nonApprovedShoppings = mainBL.ShowNonApprovedExistingShopping();
            if(nonApprovedShoppings.Count == 0)
            {
                Console.WriteLine("Tutte le spese sono state approvate");
                return 0;
            }
            else
            {
                foreach(var s in nonApprovedShoppings)
                {
                    Console.WriteLine(s.Print());
                }
                return 1;
            }
        }

        private static void AddNewShopping()
        {
            DateTime date;
            string description, user;
            decimal price;
            Category category;
            bool approved = false;

            do
            {
                Console.WriteLine("\nInserisci la data della spesa");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out date));

            do
            {
                Console.WriteLine("\nInserisci la descrzione");
                description = Console.ReadLine();
            }
            while (description.Length == 0);

            do
            {
                Console.WriteLine("\nInserisci l'utente");
                user = Console.ReadLine();
            }
            while (user.Length == 0);

            do
            {
                Console.WriteLine("\nInserisci l'importo");
            }
            while (!decimal.TryParse(Console.ReadLine(), out price));

            do
            {
                Console.WriteLine("\nInserire il nome della categoria");
                ShowCategories(); //mostra tutti i codici degli scaffali
                string name = Console.ReadLine();

                //Recupero lo scaffale con il codice inserito
                //Se esiste, ok. Altrimenti mi richiede di inserire il codice
                category = GetCategoryByName(name);
            } while (category == null);

            Shopping shopping = new Shopping
            {
                Date = date,
                Description = description,
                User = user,
                Price = price,
                Approved = approved,
                Category = category

            };
            mainBL.AddShopping(shopping);

        }

        private static Category GetCategoryByName(string name)
        {
            var category = mainBL.GetByName(name);
            return category;
        }

        private static void ShowCategories()
        {
            //recupera dati degli scaffali dal db
            var categories = mainBL.FetchCategories();

            //stampa i dati
            if (categories.Count != 0)
            {
                Console.WriteLine("Categorie: ");
                foreach (var c in categories)
                {
                    Console.WriteLine(c.Name);
                }
            }
            else
            {
                Console.WriteLine("Non ci sono categorie");
            }
        }
    }
}
