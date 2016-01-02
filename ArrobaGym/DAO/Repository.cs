﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrobaGym.DAO
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected Models.AtGymLINQDataContext context = new Models.AtGymLINQDataContext();

        public IEnumerable<T> SelectAll()
        {
            var query = from t in context.GetTable<T>()
                        select t;
            return query.AsEnumerable();
        }

        public IEnumerable<T> FindAll(Func<T, bool> exp)
        {
            var query = from t in context.GetTable<T>().Where(exp)
                        select t;
            return query.AsEnumerable();
        }

        public void SaveAll()
        {
            this.context.SubmitChanges();
        }

        public T SelectSingle(Func<T, bool> exp)
        {
            var query = from t in context.GetTable<T>().Where(exp)
                        select t;
            return query.AsEnumerable<T>().First();
        }

        public void Insert(T obj)
        {
            this.context.GetTable<T>().InsertOnSubmit(obj);
        }

        void IRepository<T>.Update(Func<T, bool> exp, T obj)
        {
            T objUpdate = this.context.GetTable<T>().Where(exp).SingleOrDefault();
            objUpdate = obj;
        }

        public void Delete(Func<T, bool> exp)
        {
            T entity = SelectSingle(exp);
            this.context.GetTable<T>().DeleteOnSubmit(entity);
        }
    }
}
