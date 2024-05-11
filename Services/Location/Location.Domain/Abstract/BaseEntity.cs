namespace Location.Domain.Abstract;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
