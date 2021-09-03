using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.GestioneSpese.Core.Models;

namespace Week6.EF.GestioneSpese.Core.Interfaces
{
    public interface IShoppingRepository : IRepository<Shopping>
    {
        List<Shopping> ShowNonApprovedExistingShopping();
        void Approve(Shopping shopping);
    }
}
