namespace Basket.API.Dtos;

public class BasketDto
{
    public string UserId { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }
    public decimal TotalPrice => BasketItems.Sum(x => x.Price * x.Quantity);
}
