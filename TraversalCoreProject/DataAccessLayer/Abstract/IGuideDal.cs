using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IGuideDal:IGenericDal<Guide>
    {
        // false ve True durumu  
        void ChangeToTrueByGuide(int id);
        void ChangeToFalseByGuide(int id);


    }
}
