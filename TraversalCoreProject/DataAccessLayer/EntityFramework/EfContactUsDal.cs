using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Respository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        private readonly Context _context;

        public EfContactUsDal(Context context)
        {
            _context = context;
        }

        public void ChangeToFalseContactUs(int id)
        {
            var contactus = _context.ContactUses.Find(id);
            contactus.Status = false;
            _context.Update(contactus);
            _context.SaveChanges();

        }

        public void ChangeToTrueContactUs(int id)
        {
            var contactus = _context.ContactUses.Find(id);
            contactus.Status = true;
            _context.Update(contactus);
            _context.SaveChanges();
        }
    }
}
