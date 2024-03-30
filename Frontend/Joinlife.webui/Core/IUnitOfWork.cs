namespace Joinlife.webui.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        int Commit();
    }
}