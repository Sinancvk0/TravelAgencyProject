namespace TraversalCoreProject.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
