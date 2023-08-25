using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
        var values=_commentDal.GetByID(id);
            return values ;
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();

        }
        public List<Comment> TGetDestinationByID(int id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationID == id);
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> GetListCommentWithDestinationandUser(int id)
        {
           return _commentDal.GetListCommentWithDestinationandUser(id);
        }
    }
}
