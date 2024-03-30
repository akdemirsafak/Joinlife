namespace Joinlife.webui.Entities
{
    public interface IAuditableEntity
    {
        DateTime? CreatedAt { get; set; }
        DateTime? LastModifiedAt { get; set; }
    }
}
