using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.Country;

public class UpdateCountryInput
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="İsim boş bırakılamaz")]
    [MinLength(2, ErrorMessage = "2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    [MaxLength(32, ErrorMessage = "2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    public string Name { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }
}