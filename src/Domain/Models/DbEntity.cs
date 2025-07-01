namespace Domain.Models;

public abstract class DbEntity
{
    public virtual int Id { get; set; }
    public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public virtual bool IsSoftDeleted { get; set; }
}
