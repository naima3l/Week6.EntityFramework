using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EntityFramework.Core.Models;

namespace Week6.EntityFramework
{
    public class Knight
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relazione 1 a molti con l'arma
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        //Relazione molti a molti con le battaglie
        public List<Battle> Battles { get; set; }  = new List<Battle>();

        //Relazione 1 a 1 con cavallo
        public Horse Horse { get; set; } //Navigation Property 
        //Cavaliere può non avere un cavallo e andare a piedi
    }
}
