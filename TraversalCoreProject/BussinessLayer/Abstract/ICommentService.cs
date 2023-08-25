using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICommentService:IGenericServices<Comment>
    {
        List<Comment> TGetDestinationByID(int id);
        List<Comment> TGetCommentWithDestination();
        public List<Comment> GetListCommentWithDestinationandUser(int id);
    }
}
