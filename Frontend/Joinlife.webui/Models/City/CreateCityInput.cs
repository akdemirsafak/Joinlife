using System.ComponentModel;

namespace Joinlife.webui.Models.City
{
    public class CreateCityInput
    {
        [DisplayName("Şehir adı")]
        public string Name { get; set; }
        public Guid CountryId { get; set; }
    }
}