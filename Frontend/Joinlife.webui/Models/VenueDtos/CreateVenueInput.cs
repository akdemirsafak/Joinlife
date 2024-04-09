using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.VenueDtos;

public sealed class CreateVenueInput
{
    [DisplayName("Ad")]
    [Required]
    [Length(2, 32,ErrorMessage ="Mekan adı 2 ila 32 karakter arasında olmalıdır.")]
    public string Name { get; set; }
    [DisplayName("Adres Ayrıntısı")]
    [MaxLength(255,ErrorMessage ="Yeterince ayrıntı verdiniz. 255 karakteri geçmemesine özen gösteriniz.")]
    public string Line { get; set; }
    public Guid CityId { get; set; }
}