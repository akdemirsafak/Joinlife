using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.EventDtos;

public sealed class CreateEventInput
{
    [DisplayName("Etkinliğin Adı")]
    [Required(ErrorMessage = "İsim boş bırakılamaz")]
    [MinLength(2, ErrorMessage = "2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    [MaxLength(32, ErrorMessage = "2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    public string Name { get; set; }
    [DisplayName("Açıklama")]
    [MaxLength(255,ErrorMessage ="Maksimum 255 karakterden oluşan bir açıklama yapabilirsiniz.")]
    public string? Description { get; set; }
    [Required]
    public int EventTypeId { get; set; }
    public Guid VenueId { get; set; }
    public int StatuId { get; set; } = 1;
    [Required]
    public DateTime StartDateTime { get; set; }
    [Required]
    public DateTime EndDateTime { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile Image { get; set; }
}