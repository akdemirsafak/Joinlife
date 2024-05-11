using Joinlife.webui.Models.City;

namespace Joinlife.webui.Models.Country
{
    public class GetCountryByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<GetCityResponse> Cities { get; set; }
    }
}