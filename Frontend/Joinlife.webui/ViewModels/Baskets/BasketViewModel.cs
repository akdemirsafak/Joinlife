namespace Joinlife.webui.ViewModels.Baskets;

public class BasketViewModel
{
    public Guid UserId { get; set; }
    private List<BasketItemViewModel> _basketItems;
    public List<BasketItemViewModel> BasketItems
    {
        get
        {
            return _basketItems;
        }
        set
        {
            _basketItems = value;
        }
    }
    public decimal TotalPrice { get => _basketItems.Sum(x => x.CurrentPrice); }
    public BasketViewModel()
    {
        BasketItems = new List<BasketItemViewModel>();
    }
}
