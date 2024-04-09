using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.City;

public class UpdateCityInput
{
    public Guid Id { get; set; }
    [DisplayName("Şehir adı")]
    [Required(ErrorMessage ="Şehir adı boş geçilemez.")]
    [Length(2, 32, ErrorMessage = "Şehir adı 2 ila 32 karakter arası olmalıdır.")]
    public string Name { get; set; }
    public Guid CountryId { get; set; }
}