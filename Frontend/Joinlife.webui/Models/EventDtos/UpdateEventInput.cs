using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.EventDtos;

public sealed class UpdateEventInput
{
    public Guid Id { get; set; }
    [DisplayName("Etkinliğin Adı")]
    [Required(ErrorMessage = "İsim boş bırakılamaz")]
    [MinLength(2, ErrorMessage = "2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    [MaxLength(32, ErrorMessage = "2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    public string Name { get; set; }
    [DisplayName("Etkinlik Açıklaması")]
    public string Description { get; set; }
    [Required]
    public int EventTypeId { get; set; }
    public Guid VenueId { get; set; }
    [Required]
    public DateTime StartDateTime { get; set; }
    [Required] 
    public DateTime EndDateTime { get; set; }
    [Required] 
    public int StatuId { get; set; }

}