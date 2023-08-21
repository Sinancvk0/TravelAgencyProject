using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.CQRS.Queries.DestinationQuery;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        private readonly CreateDestinationCommandHandlers _createDestinationCommandHandlers;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandlers;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandlers;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, CreateDestinationCommandHandlers createDestinationCommandHandlers, RemoveDestinationCommandHandler removeDestinationCommandHandlers, UpdateDestinationCommandHandler updateDestinationCommandHandlers)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
            _createDestinationCommandHandlers = createDestinationCommandHandlers;
            _removeDestinationCommandHandlers = removeDestinationCommandHandlers;
            _updateDestinationCommandHandlers = updateDestinationCommandHandlers;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()

        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandlers.Handle(command);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandlers.Handel(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");


        }


        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));

            return View(values);

        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {

            _updateDestinationCommandHandlers.Handle(command);

            return RedirectToAction("Index");

        }

    }
}
