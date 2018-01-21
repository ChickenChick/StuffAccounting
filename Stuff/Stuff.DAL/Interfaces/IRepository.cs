using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuff.DAL.Interfaces
{
    interface IRepository<T>
    {
        IEnumerable<T> Read();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
