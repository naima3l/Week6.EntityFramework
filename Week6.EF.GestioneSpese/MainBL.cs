using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.GestioneSpese.Core.Interfaces;
using Week6.EF.GestioneSpese.Core.Models;

namespace Week6.EF.GestioneSpese
{
    public class MainBL
    {
        private IShoppingRepository _shoppingRepo;
        private ICategoryRepository _categoryRepo;
        public MainBL(IShoppingRepository shoppingRepository, ICategoryRepository categoryRepository)
        {
            _shoppingRepo = shoppingRepository;
            _categoryRepo = categoryRepository;
        }

        internal Category GetByName(string name)
        {
            return _categoryRepo.GetByName(name);
        }

        internal List<Category> FetchCategories()
        {
            return _categoryRepo.Fetch();
        }

        internal void AddShopping(Shopping shopping)
        {
             _shoppingRepo.Add(shopping);
        }

        internal List<Shopping> ShowNonApprovedExistingShopping()
        {
            return _shoppingRepo.ShowNonApprovedExistingShopping();
        }

        internal Shopping GetById(int id)
        {
            return _shoppingRepo.GetById(id);
        }

        internal void Approve(Shopping shopping)
        {
            _shoppingRepo.Approve(shopping);
        }
    }
}
