namespace Joinlife.webui.Entities;

public class Organizer : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Event> Events { get; set; }
}
