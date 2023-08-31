using MVCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCV.Repositories
{
    //We defined a generic for this class. We assigned a condition.
    public class GenericRepository<T> where T : class,new()
    {
        DbCVEntities db = new DbCVEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void Delete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void Update(T p)
        {
            db.SaveChanges();
        }
        //Finding the id of the incoming value
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}