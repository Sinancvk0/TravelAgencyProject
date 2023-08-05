using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IGuideDal
    {
        void Insert(Guide guide);
        void Delete(Guide guide);

        void Update(Guide guide);
        List<Guide> GetList();
    }
}
