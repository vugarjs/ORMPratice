using ORMPratice.Entities;

namespace ORMPratice.Services;

public class GroupService
{
    public void AddGroup(Group group)
    {
        using (var context = new Contexts.UniversityDb())
        {
            context.Groups.Add(group);
            Console.WriteLine("Group added successfully.");
            Console.WriteLine($"Name: {group.Name}, Limit: {group.Limit}");
            context.SaveChanges();
        }
    }
    public void UpdateGroup(Group group, string name, int limit)
    {
        using (var context = new Contexts.UniversityDb())
        {
            group.Name = name;
            group.Limit = limit;
            Console.WriteLine("Group updated successfully.");
            Console.WriteLine($"Name: {group.Name}, Limit: {group.Limit}");
            context.SaveChanges();
        }
    }
    public void DeleteGroup(Group group)
    {
        using (var context = new Contexts.UniversityDb())
        {
            context.Groups.Remove(group);
            Console.WriteLine("Group deleted successfully.");
            Console.WriteLine($"Name: {group.Name}, Limit: {group.Limit}");
            context.SaveChanges();
        }
    }
    public void GetAllGroups()
    {
        using (var context = new Contexts.UniversityDb())
        {
            var groups = context.Groups.ToList();
            foreach (var group in groups)
            {
                Console.WriteLine($"ID: {group.Id}, Name: {group.Name}, Limit: {group.Limit}");
            }
        }
    }
    public Group? GetGroupById(int id)
    {
        using (var context = new Contexts.UniversityDb())
        {
            var group = context.Groups.FirstOrDefault(g => g.Id == id);
            if (group != null)
            {
                Console.WriteLine($"Name: {group.Name}, Limit: {group.Limit}");
            }
            else
            {
                Console.WriteLine($"Group with ID {id} not found.");
            }
            return group;
        }
    }
    public void GetStudentsByGroupId(int groupId)
    {
        using (var context = new Contexts.UniversityDb())
        {
            var group = context.Groups.FirstOrDefault(g => g.Id == groupId);
            List<Student> students = context.Students.Where(s => s.GroupId == groupId).ToList();
            if (group != null)
            {
                Console.WriteLine($"Students in Group: {group.Name}, ID: {group.Id}");
                foreach (var student in students)
                {
                    Console.WriteLine($"Name: {student.Name}, Email: {student.Email}");
                }
            }
            else
            {
                Console.WriteLine($"Group with ID {groupId} not found.");
            }
        }
    }
    public Group? SearchByName(string name)
    {
        using (var context = new Contexts.UniversityDb())
        {
            var group = context.Groups.FirstOrDefault(g => g.Name == name);
            if (group != null)
            {
                Console.WriteLine($"Name: {group.Name}, Limit: {group.Limit}");
            }
            else
            {
                Console.WriteLine($"Group with Name {name} not found.");
            }
            return group;
        }
    }
}
