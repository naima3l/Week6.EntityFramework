using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EF.GestioneSpese.Core.Models
{
    public class Shopping
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string User { get; set; }
        public decimal Price { get; set; }
        public bool Approved { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public string Print()
        {
            return $"Id : {Id}, Data : {Date}, Descrzione : {Description}, Utente : {User}, Importo : {Price}, Approvato : {Approved}, Categoria : {Category.Name}";
        }
    }
}
