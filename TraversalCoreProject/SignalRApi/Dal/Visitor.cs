using System;

namespace SignalRApi.Dal
{
    public enum ECity
    {
        İstanbul=1,
        Ankara=2,
        Zonguldak=3,
        İzmir=4,
        Adana=5


    }
    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }

        public int CityVisitCount { get; set; }

        public DateTime  VisitDate { get; set; }

    }
}
