using System.Collections.ObjectModel;

namespace Joinlife.webui.Entities;

public sealed class Order : EntityBase, IAuditableEntity
{
    public Guid BuyerId { get; set; }
    public Collection<OrderItem> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
