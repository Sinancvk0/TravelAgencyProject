using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Respository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var context = new Context()) // Corrected the typo ("Contect" -> "Context")
            {
                return context.Destinations.Where(x=>x.DestinationID==id).Include(c => c.Guide) 
                    .FirstOrDefault();
            }
            
        }

        public List<Destination> GetLast4Destinations()
        {
            using (var context = new Context())
            {
                var values=context.Destinations.Take(4).OrderByDescending(x=>x.DestinationID).ToList();
                return values;

            }
        }
    }
}
