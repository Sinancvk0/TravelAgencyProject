using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Respository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
    

        public void ChangeToFalseContactUs(int id)
        {
            using (var _context = new Context())
            {
                var contactus = _context.ContactUses.Find(id);
                contactus.Status = false;
                _context.Update(contactus);
                _context.SaveChanges();

            }
       

        }

        public void ChangeToTrueContactUs(int id)
        {
            using (var _context = new Context())
            {

                var contactus = _context.ContactUses.Find(id);
                contactus.Status = true;
                _context.Update(contactus);
                _context.SaveChanges();
            }
         
        }
    }
}
