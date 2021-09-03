using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.GestioneSpese.Core.Interfaces;
using Week6.EF.GestioneSpese.Core.Models;

namespace Week6.EF.GestioneSpese.EF.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ShoppingContext ctx;

        public EFCategoryRepository()
        {
            ctx = new ShoppingContext();
        }
        public void Add(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Category> Fetch()
        {
            return ctx.Category.ToList();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetByName(string name)
        {
            //validazione
            if (string.IsNullOrEmpty(name))
                return null;

            var c = ctx.Category.Where(cat => cat.Name == name).FirstOrDefault();
            return c;
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
