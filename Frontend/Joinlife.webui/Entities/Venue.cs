namespace Joinlife.webui.Entities
{
    public sealed class Venue : EntityBase
    {
        public string Name { get; set; }
        public string Line { get; set; } //Adress
        public City City { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
