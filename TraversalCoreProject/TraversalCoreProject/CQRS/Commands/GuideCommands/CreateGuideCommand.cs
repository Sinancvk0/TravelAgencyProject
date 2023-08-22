using MediatR;

namespace TraversalCoreProject.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {
        public string Name { get; set; }

        public string Descripition { get; set; }
    
        public bool Status { get; set; }
    }
}
