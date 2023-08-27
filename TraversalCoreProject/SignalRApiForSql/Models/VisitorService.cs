using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApiForSql.Dal;
using SignalRApiForSql.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApiForSql.Models
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
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());

        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "select tarih,[1],[2],[3],[4],[5] from (select [City],CityVisitCount,CAST([VisitDate] as Date) as tarih from Visitors)as visitTable Pivot(Sum(CityVisitCount)For City in([1],[2],[3],[4],[5]))as pivottable order by tarih asc";
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
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                vchart.Counts.Add(x);

                            }
                            else
                            {
                                vchart.Counts.Add(reader.GetInt32(x));

                            }


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
