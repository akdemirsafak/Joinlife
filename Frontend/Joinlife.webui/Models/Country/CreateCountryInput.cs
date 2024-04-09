using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.Country;

public class CreateCountryInput
{
    [Required(ErrorMessage ="İsim boş bırakılamaz")]
    //[Length(2, 32,ErrorMessage ="2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    [MinLength(2,ErrorMessage ="2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    [MaxLength(32,ErrorMessage ="2 ile 32 karakter arasında bir isim belirlemelisiniz.")]
    public string Name { get; set; }
}