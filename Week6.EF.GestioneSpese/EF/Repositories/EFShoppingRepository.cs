using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.GestioneSpese.Core.Interfaces;
using Week6.EF.GestioneSpese.Core.Models;

namespace Week6.EF.GestioneSpese.EF.Repositories
{
    public class EFShoppingRepository : IShoppingRepository
    {
        private readonly ShoppingContext ctx;

        public EFShoppingRepository()
        {
            ctx = new ShoppingContext();
        }
        public void Add(Shopping item)
        {
            var category = ctx.Category
               .FirstOrDefault(c => c.Id == item.Category.Id);
            category.shoppings.Add(item);
            //ctx.Shoppings.Add(new Shopping {Date = item.Date, Description = item.Description, User = item.User, Price = item.Price, Approved = item.Approved, CategoryId = item.CategoryId });
            //ctx.Shoppings.Add(new Shopping
            //{
            //    Date = item.Date,
            //    Description = item.Description,
            //    User = item.User,
            //    Price = item.Price,
            //    Approved = item.Approved,
            //    CategoryId = item.CategoryId
            //});
            ctx.SaveChanges();
        }

        public void Approve(Shopping shopping)
        {
            var sh = ctx.Shoppings.FirstOrDefault(s => s.Id == shopping.Id);
            sh.Approved = true;
            ctx.SaveChanges();
        }

        public void Delete(Shopping item)
        {
            ctx.Shoppings.Remove(item);
            ctx.SaveChanges();
        }

        public List<Shopping> Fetch()
        {
            try
            {
                var shoppings = ctx.Shoppings.Include(s => s.Category)
                    .ToList();
                return shoppings;
            }
            catch (Exception)
            {
                return new List<Shopping>();
            }
        }

        public Shopping GetById(int id)
        {
            var s = ctx.Shoppings.Find(id);
            return s;
        }

        public List<Shopping> ShowNonApprovedExistingShopping()
        {
            try
            {
                var shoppings = ctx.Shoppings.Include(s => s.Category)
                    .Where(s=> s.Approved == false)
                    .ToList();
                return shoppings;
            }
            catch (Exception)
            {
                return new List<Shopping>();
            }
        }

        public void Update(Shopping item)
        {
            throw new NotImplementedException();
        }
    }
}
