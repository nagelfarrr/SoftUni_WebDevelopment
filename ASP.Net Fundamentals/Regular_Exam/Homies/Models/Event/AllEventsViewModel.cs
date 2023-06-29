namespace Homies.Models.Event
{
	public class AllEventsViewModel
	{
       
        public int Id { get; set; }
                
        public string Organiser { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}
