using System.Collections.Generic;

namespace SignalRApi.Models
{
    public class VisitorChart
    {
        public VisitorChart()
        {
            Counts=new List<int>();
                
        }

        public string VisitDate { get; set; }
        public List<int> Counts { get; set; }
    }
}
