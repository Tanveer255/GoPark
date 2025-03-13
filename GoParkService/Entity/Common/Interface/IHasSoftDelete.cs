namespace GoParkService.Entity.Common.Interface;

public interface IHasSoftDelete
{
    public bool IsDeleted { get; set; }
    DateTime UpdatedAt { get; set; }
}
