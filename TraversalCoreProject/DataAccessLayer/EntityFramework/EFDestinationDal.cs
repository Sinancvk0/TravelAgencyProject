using DataAccessLayer.Abstract;
using DataAccessLayer.Respository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal:GenericRepository<Destination>,IDestinationDal
    {
    }
}
