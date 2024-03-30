
namespace Joinlife.webui.Entities
{
    public sealed class Country : EntityBase
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
