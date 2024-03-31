using System.ComponentModel;

namespace Joinlife.webui.Models.VenueDtos
{
    public sealed class CreateVenueInput
    {
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Adres Ayrıntısı")]
        public string Line { get; set; }
        public Guid CityId { get; set; }
    }
}