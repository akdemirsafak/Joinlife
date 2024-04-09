using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.City;

public sealed class CreateCityInput
{
    [DisplayName("Şehir adı")]
    [Required(ErrorMessage = "Şehir adı boş geçilemez.")]
    [Length(2,32,ErrorMessage ="Şehir adı 2 ila 32 karakter arası olmalıdır.")]
    public string Name { get; set; }
    public Guid CountryId { get; set; }
}