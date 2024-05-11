using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.VenueDtos;

public sealed class UpdateVenueInput
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Mekan adı girmelisiniz.")]
    [Length(2, 32, ErrorMessage = "Mekan adı 2 ila 32 karakter arası olabilir.")]
    public string Name { get; set; }
    [DisplayName("Adres Ayrıntısı")]
    [MaxLength(255, ErrorMessage = "Yeterince ayrıntı verdiniz. 255 karakteri geçmemesine özen gösteriniz.")]
    public string Line { get; set; }
    public int Capacity { get; set; }
    public Guid CityId { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }
}