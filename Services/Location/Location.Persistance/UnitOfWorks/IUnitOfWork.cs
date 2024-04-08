namespace Location.Persistance.UnitOfWorks;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    int SaveChanges();
}
