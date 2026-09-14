namespace ORMPratice.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Limit { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
