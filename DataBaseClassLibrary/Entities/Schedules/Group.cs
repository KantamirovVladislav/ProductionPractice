namespace DataBaseClassLibrary.Entities.Schedules;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public int SpecialtyId { get; set; }

    public int Course { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Specialty Specialty { get; set; } = null!;
}
