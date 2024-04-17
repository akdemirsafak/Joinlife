using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Joinlife.webui.ViewModels.Orders;

public class CheckoutInfoInput
{
    [Required(ErrorMessage = "Kart sahibi adı soyadı boş bırakılamaz.")]
    [DisplayName("Kart sahibi adı soyadı : ")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Geçerli bir isim giriniz.")]
    public string CardName { get; set; }

    [Required(ErrorMessage = "Kart numarası boş bırakılamaz.")]
    [DisplayName("Kart Numarası : ")]
    [DataType(DataType.CreditCard)]
    //[RegularExpression(@"^((4\d{3})|(5[1-5]\d{2})|(6011)|(34\d{1})|(37\d{1}))-?\d{4}-?\d{4}-?\d{4}|3[4,7]\d{13}$", ErrorMessage = "Geçerli bir kart numarası giriniz.")]
    public string CardNumber { get; set; }


    [Required(ErrorMessage = "Son kullanma tarihi boş bırakılamaz.")]
    [DataType(DataType.Date)]
    [DisplayName("son kullanma tarihi ay/yıl : ")]
    //[RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "Geçerli bir son kullanma tarihi giriniz.")]
    public string ExpirationDate { get; set; }

    [Required(ErrorMessage = "CVV veya CVC boş bırakılamaz.")]
    [DisplayName("CVV veya CVC : ")]
    [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Geçerli bir CVV/CVC numarası giriniz.")]
    public string CVV { get; set; }


    [Required(ErrorMessage = "Toplam tutar boş bırakılamaz.")]
    [DisplayName("Toplam Tutar : ")]
    //[DataType(DataType.Currency)]
    public decimal TotalPrice { get; set; }
}
