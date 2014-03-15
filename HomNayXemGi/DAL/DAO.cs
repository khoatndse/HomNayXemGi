using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayXemGi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;


namespace HomNayXemGi.DAL
{
    public class DAO<T> : DALInterface<T> where T : class
    {

        public IList<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            var context = new MovieSchedulerEntities();
            return context.CreateObjectSet<T>().ToList();
        }

        public IList<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            return GetAll();
        }

        public void Add(params T[] items)
        {
            using (var context = new MovieSchedulerEntities())
            {
                foreach (T item in items)
                {
                    context.CreateObjectSet<T>().AddObject(item);

                }
                context.SaveChanges();
            }
        }

        public void Update(params T[] items)
        {
            using (var context = new MovieSchedulerEntities())
            {
                foreach (T item in items)
                {
                    context.CreateObjectSet<T>().Attach(item);
                    context.ObjectStateManager.ChangeObjectState(item, System.Data.EntityState.Modified);
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }

        public void Remove(params T[] items)
        {
            using (var context = new MovieSchedulerEntities())
            {
                foreach (T item in items)
                {
                    context.CreateObjectSet<T>().DeleteObject(item);
                }
                context.SaveChanges();
            }
        }


        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            var context = new MovieSchedulerEntities();

                return context.CreateObjectSet<T>().FirstOrDefault(predicate);
        }
    }
}