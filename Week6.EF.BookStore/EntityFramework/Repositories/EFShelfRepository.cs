using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.BookStore.Core.Interfaces;
using Week6.EF.BookStore.Core.Models;

namespace Week6.EF.BookStore.EntityFramework.Repositories
{
    class EFShelfRepository : IShelfRepository
    {
        private readonly BookContext ctx;

        public EFShelfRepository()
        {
            ctx = new BookContext();
        }
        public void Add(Shelf item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Shelf item)
        {
            throw new NotImplementedException();
        }

        public List<Shelf> Fetch()
        {
            return ctx.Shelves.ToList();
        }

        public Shelf GetByCode(string code)
        {
            //validazione
            if (string.IsNullOrEmpty(code))
                return null;

            var shelf = ctx.Shelves.Where(s => s.Code == code).FirstOrDefault();
            return shelf;
        }

        public Shelf GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Shelf item)
        {
            throw new NotImplementedException();
        }
    }
}
