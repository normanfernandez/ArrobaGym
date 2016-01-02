using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrobaGym.DAO
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        IEnumerable<T> FindAll(Func<T,bool> exp);
        T SelectSingle(Func<T,bool> exp);
        void Insert(T obj);
        void Update(Func<T, bool> exp, T obj);
        void Delete(Func<T, bool> exp);
        void SaveAll();
    }
}
