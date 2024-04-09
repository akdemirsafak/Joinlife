using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.Auth;

public class SignupInputModel
{
    [Required,DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DisplayName("Kullanıcı adı : ")]
    [Required(ErrorMessage ="Kullanıcı adı girmelisiniz.")]
    [Length(2,16,ErrorMessage ="Kullanıcı adı 2-16 karakter arası olabilir.")]
    public string Username { get; set; }
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
}
