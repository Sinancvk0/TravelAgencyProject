using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class DestinationManager:IDestinationService
    {
        IDestinationDal _desrinationDal;

        public DestinationManager(IDestinationDal desrinationDal)
        {
            _desrinationDal = desrinationDal;
        }

        public void TAdd(Destination t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Destination t)
        {
            throw new NotImplementedException();
        }

        public Destination TGetByID(int id)
        {
           return _desrinationDal.GetByID(id);
        }

        public List<Destination> TGetList()
        {
           return _desrinationDal.GetList();
        }

        public void TUpdate(Destination t)
        {
            throw new NotImplementedException();
        }
    }
}
