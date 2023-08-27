using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Dal;
using SignalRApi.Hubs;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.Models
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();

        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", "ccccc");

        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "SELECT * FROM crosstab(" +
            "'SELECT \"VisitDate\", \"City\", \"CityVisitCount\" " +
            " FROM \"Visitors\" " +
            " ORDER BY 1, 2'" +
            ") AS ct (\"VisitDate\" timestamp, City1 int, City2 int, City3 int, City4 int)";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart vchart = new VisitorChart();

                        vchart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            vchart.Counts.Add(reader.GetInt32(x));

                        });
                        visitorCharts.Add(vchart);

                    }


                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }



        }
    }
}
