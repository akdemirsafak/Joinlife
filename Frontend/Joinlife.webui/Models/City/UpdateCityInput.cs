using System.ComponentModel;

namespace Joinlife.webui.Models.City
{
    public class UpdateCityInput
    {
        public Guid Id { get; set; }
        [DisplayName("Şehir adı")]
        public string Name { get; set; }
        public Guid CountryId { get; set; }
    }
}