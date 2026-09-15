using ORMPratice.Entities;
namespace ORMPratice.Services;

internal class StudentService
{
    public void AddStudent(Student student)
    {
        using (var context = new Contexts.UniversityDb())
        {
            context.Students.Add(student);
            Console.WriteLine("Student added successfully.");
            Console.WriteLine($"Name: {student.Name}, Email: {student.Email}, Group: {student.Group}");
            context.SaveChanges();
        }
    }
    public void UpdateStudent(Student student, string name, string email, int groupID, string surname)
    {
        using (var context = new Contexts.UniversityDb())
        {
            student.Name = name;
            student.Email = email;
            student.Surname = surname;
            student.GroupId = groupID;
            Console.WriteLine("Student updated successfully.");
            Console.WriteLine($"Name: {student.Name}, Email: {student.Email}, Group: {student.Group}");
            context.SaveChanges();
        }
    }
    public void DeleteStudent(Student student)
    {
        using (var context = new Contexts.UniversityDb())
        {
            context.Students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
            Console.WriteLine($"Name: {student.Name}, Email: {student.Email}, Group: {student.Group}");
            context.SaveChanges();
        }
    }
    public void GetAllStudents()
    {
        using (var context = new Contexts.UniversityDb())
        {
            List<Student> students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Email: {student.Email}, Group: {student.GroupId}");
            }
        }
    }
    public Student? GetStudentById(int id)
    {
        using (var context = new Contexts.UniversityDb())
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Email: {student.Email}, Group ID: {student.GroupId}");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
            return student;
        }
    }
    public Student? SearchByName(string name)
    {
        using (var context = new Contexts.UniversityDb())
        {
            var student = context.Students.FirstOrDefault(s => s.Name == name);
            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Email: {student.Email}, Group: {student.Group}");
            }
            else
            {
                Console.WriteLine($"Student with Name {name} not found.");
            }
            return student;
        }
    }
}
