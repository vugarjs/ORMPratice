namespace ORMPratice.Entities;

internal class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}

