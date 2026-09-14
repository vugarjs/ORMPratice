namespace ORMPratice.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; } 
}

