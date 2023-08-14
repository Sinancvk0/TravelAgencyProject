using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Respository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestination()
        {
            using (var context = new Context()) // Corrected the typo ("Contect" -> "Context")
            {
                return context.Comments
                    .Include(c => c.Destination) // Assuming Destination is a navigation property in Comment entity
                    .ToList();
            }
        }
    }
}
