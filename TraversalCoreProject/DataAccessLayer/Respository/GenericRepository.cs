using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetList()
        {
        var c=new Context();
         return   c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            var c = new Context();
            c.Add(t);
           
        }

        public void Update(T t)
        {
            var c = new Context();
            c.Update(t);
          
        }
    }
}
