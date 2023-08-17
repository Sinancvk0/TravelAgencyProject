using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Respository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataAccessLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        private readonly Context _context;

        public EfGuideDal()
        {
        }

        public EfGuideDal(Context context)
        {
            _context = context;
        }

        public void ChangeToFalseByGuide(int id)
        {
            var guide = _context.Guides.Find(id);
          
                guide.Status = false;
                _context.Update(guide);   
                _context.SaveChanges();

        

        }

        public void ChangeToTrueByGuide(int id)
        {

            var guide = _context.Guides.Find(id);
           
                guide.Status = true;
                _context.Update(guide);
                _context.SaveChanges();

        }
    }
}
