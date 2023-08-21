using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Queries.DestinationQuery;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);

            return new GetDestinationByIDQueryResult
            {
                DesitnationID = values.DestinationID,
                City = values.City,
                Daynight = values.DayNight,
                Price = values.Price

            };


        }
    }
}
