using Joinlife.webui.Entities;

namespace Joinlife.webui.Models.Country
{
    public class GetByIdCountryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}