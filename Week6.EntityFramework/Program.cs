using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Week6.EntityFramework.Core.Models;
using Week6.EntityFramework.EntityFramework;

namespace Week6.EntityFramework
{
    class Program
    {
        //Istanza di KinigtsContext
        private static KnightsContext _knightsContext = new KnightsContext();
        static void Main(string[] args)
        {
            _knightsContext.Database.EnsureCreated(); //per assicurarsi dell'esistenza del db. Se non esiste lo crea (questo metodo si usa nei test)


            //Recuperiamo tutti i cavalieri
            //Console.WriteLine("Prima dell'aggiunta");
            //FetchKnights();

            //Aggiungiamo un cavaliere
            //AddKnight();

            //Recuperiamo tutti i cavalieri dopo l'aggiunta
            //Console.WriteLine("Dopo l'aggiunta");
            //FetchKnights();

            //Aggiunta tipi diversi
            //AddVariousTypes();

            //Filtrare tutti i cavalieri con nome Telman

            //Recuperare il primo con nome Telman

            //Recuperare un cavaliere con un certo Id (2 modi)

            //Update cavaliere
            //GetAndUpdateKnight();

            //Delete cavaliere
            // GetAndDelete();

            //Metodo per recuperare tutte le battaglie e modificare le date
            //RetrieveAndUpdateBattles();

            //Metodo per aggiungere un cavaliere con una o più armi
            //AddKnightWithWeapon();

            //Metodo per aggiungere una o più armi a un cavaliere esistente
            //AddNewWeaponToExistingKnight_Disconnected();

            //Metodo per aggiungere una o più armi a un cavaliere esistente con attach
            //AddNewWeaponToExistingKnight_Disconnected_Attach();

            //Metodo per recuperare cavalieri e le armi dei cavalieri
            //EagerLoadingKnightWithWeapons();

            //Metodo per recuperare cavalieri che hanno come arma l'Ascia
            EagerLoadingKnightWithWeapons_Filter();
        }

        //PARTE 1

        #region Caricamento dei dati correlati
        //Eager loading

        //Recuperare cavalieri e le armi dei cavalieri
        private static void EagerLoadingKnightWithWeapons()
        {
            var knights = _knightsContext.Knights.ToList();
            //se voglio recuperare sia il cavaliere che le sue armi devo usare include

            var knightsWithWeapons = _knightsContext.Knights.Include(k => k.Weapons).ToList();
        }

        //Recuperare cavalieri e solo le armi con descrizione Ascia
        private static void EagerLoadingKnightWithWeapons_Filter()
        {
            /*var knightsWithAscia = _knightsContext.Knights.Include(k => k.Weapons
            .Where(w => w.Description == "Ascia"))
            .ToList();*/

            var www = _knightsContext.Weapons.Where(w => w.Description == "Spada").Include(k => k.Knight).ToList();
        }

        //QUERY PROJECTIONS

        //Solo id e nome del cavaliere
        private static void IdAndName_AnonimousType()
        {
            var knights = _knightsContext.Knights
                .Select(k => new { k.Id, k.Name }).ToList();
        }

        public struct IdAndName
        {
            public int Id;
            public string Name;

            public IdAndName(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public static void IdAndName_Struct()
        {
            var knights = _knightsContext.Knights
                .Select(k => new IdAndName (k.Id, k.Name ))
                .ToList();
        }

        //EXPLICIT LOADING
        private static void ExplicitLoading()
        {
            var knight = _knightsContext.Knights.Find(6);
            _knightsContext.Entry(knight).Collection(k => k.Weapons).Load();
            _knightsContext.Entry(knight).Reference(k => k.Horse).Load(); //LOAD SOLO SU ELEMENTI SINGOLI, NON LISTA
        }

        //LAZY LOADING
        #endregion

        private static void FetchKnights()
        {
            //QUERY LINQ
            var knights = _knightsContext.Knights.ToList();

            //var query = _knightsContext.Knights;
            //var knights = query.ToList();

            //Stampiamo il numero di record di cavalieri nel db
            Console.WriteLine($"Il numero di cavalieri è : {knights.Count}");

            //Stampiamo il nome dei cavalieri nel db
            foreach(var k in knights)
            {
                Console.WriteLine(k.Name);
            }

            //foreach(var k in _knightsContext.Knights)
            //{
            //    Console.WriteLine(k.Name);
            //} //POCO PERFORMANTE
        }

        private static void AddKnight()
        {
            var newKnight = new Knight { Name = "Bober" }; //avrà una lista di armi vuota

            _knightsContext.Knights.Add(newKnight);

            _knightsContext.SaveChanges();
        }

        private static void AddVariousTypes()
        {
            _knightsContext.AddRange(
                new Knight { Name = "Driacco" },
                new Battle { Name = "Cassel" }
                );

            _knightsContext.SaveChanges();
        }

        private static void GetByName()
        {
            var knights = _knightsContext.Knights.Where(k => k.Name == "Telman").ToList();
        }

        private static void FilterByName()
        {
            var name = "Driacco";
            var knights = _knightsContext.Knights.Where(k => k.Name == name).ToList();
        }

        private static void GetFirstByName()
        {
            var name = "Telman";
            //var knight = _knightsContext.Knights.Where(k => k.Name == name).First();
            //var knight = _knightsContext.Knights.Where(k => k.Name == name).FirstOrDefault(); // se non trova nulla dà null
            var knight = _knightsContext.Knights.FirstOrDefault(k => k.Name == name);
        }

        public static void GetKnightById()
        {
            var knight = _knightsContext.Knights.FirstOrDefault(k => k.Id == 2);
        }

        public static void GetKnightById_Find()
        {
            var knight = _knightsContext.Knights.Find(2);
        }

        public static void GetAndUpdateKnight()
        {
            var knight = _knightsContext.Knights.FirstOrDefault();

            knight.Name = "Valfred";

            _knightsContext.SaveChanges();
        }

        public static void GetAndDelete()
        {
            //voglio cancellare un cavaliere tramite il suo id
            var knight = _knightsContext.Knights.Find(4);

            _knightsContext.Knights.Remove(knight);

            _knightsContext.SaveChanges();
        }

        //Metodo per aggiungere una o più armi a un cavaliere esistente
        private static void AddWeaponToExistingKnight()
        {
            var knight = _knightsContext.Knights.FirstOrDefault();
            knight.Weapons.Add(new Weapon
            {
                Description = "Ascia"
            });

            _knightsContext.SaveChanges();
        }
        
        //PERSISTENZA DEI DATI IN SCENARI DISCONNESSI

        //Metodo per recuperare tutte le battaglie e modificare le date
        private static void RetrieveAndUpdateBattles()
        {
            List<Battle> disconnectedBattles = new List<Battle>();

            using(var context = new KnightsContext())
            {
                //recupero le battaglie e chiudo contesto
                disconnectedBattles = context.Battles.ToList();
            }

            //modificare le date delle battaglie
            disconnectedBattles.ForEach(b =>
            {
                b.StartDate = new DateTime(700, 01, 01);
                b.EndDate = new DateTime(700, 12, 01);
            });

            //salvare i cambiamenti sul database creando un nuovo contesto
            using(var ctx = new KnightsContext())
            {
                ctx.UpdateRange(disconnectedBattles);

                ctx.SaveChanges();
            }
        }

        //Metodo per aggiungere un cavaliere con una o più armi
        private static void AddKnightWithWeapon()
        {
            var knight = new Knight
            {
                Name = "Lancillotto",
                Weapons = new List<Weapon>
                {
                    new Weapon
                    {
                        Description = "Scimitarra"
                    }
                }
            };

            _knightsContext.Knights.Add(knight);
            _knightsContext.SaveChanges();
        }

        //Metodo per aggiungere una o più armi a un cavaliere esistente (disconnected)
        private static void AddNewWeaponToExistingKnight_Disconnected()
        {
            var knight = _knightsContext.Knights.Find(2);
            knight.Weapons.Add(new Weapon
            {
                Description = "Giavellotto"
            });

            using(var ctx = new KnightsContext())
            {
                ctx.Knights.Update(knight);
                ctx.SaveChanges();
            }
        }

        private static void AddNewWeaponToExistingKnight_Disconnected_Attach()
        {
            var knight = _knightsContext.Knights.Find(6);
            knight.Weapons.Add(new Weapon
            {
                Description = "Spada"
            });

            using (var ctx = new KnightsContext())
            {
                ctx.Knights.Attach(knight);
                ctx.SaveChanges();
            }
        }


    }
}
