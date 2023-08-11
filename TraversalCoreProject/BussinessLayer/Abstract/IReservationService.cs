using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IReservationService:IGenericServices<Reservation>
    {

        //List<Reservation> GetListApprovalReservation(int id);
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationByWaitAccepted(int id);
        List<Reservation> GetListWithReservationByPrevious(int id);

    }
}
