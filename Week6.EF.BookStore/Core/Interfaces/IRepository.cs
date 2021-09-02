using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EF.BookStore.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);

    }
}
