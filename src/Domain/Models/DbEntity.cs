namespace Domain.Models;

public abstract class DbEntity
{
    public virtual int Id { get; set; }
    public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public virtual bool IsSoftDeleted { get; set; }
}
