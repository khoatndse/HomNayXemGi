using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace HomNayXemGi.DAL
{
    public interface DALInterface<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Expression<Func<T,bool>> predicate);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}