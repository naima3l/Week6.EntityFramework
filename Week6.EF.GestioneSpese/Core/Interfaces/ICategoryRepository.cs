using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.GestioneSpese.Core.Models;

namespace Week6.EF.GestioneSpese.Core.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);
    }
}
