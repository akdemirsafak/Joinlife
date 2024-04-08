using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.Models.Auth;

public record SignupInputModel(
 [Required]
string Email,
 [Required]
string Username,
 [Required]
string Password);
