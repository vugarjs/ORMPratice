using Microsoft.EntityFrameworkCore;
using ORMPratice.Entities;

namespace ORMPratice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new Contexts.UniversityDb();
            bool isConnected = context.Database.CanConnect();
            if(isConnected)
            {
                Student student = new Student()
                {
                    Name = "John",
                    Surname = "Doe",
                    Email = "aasa@gmail.com",
                    BirthDate = new DateTime(1990, 1, 1)
                };
                //context.Add(student);
                //context.SaveChanges
                //List<Student> allStudents = context.Students.ToList();
                //foreach (var item in allStudents)
                //{
                //    Console.WriteLine($"{item.Name} {item.Surname} - {item.Email} - {item.BirthDate}");
                //}
                //Console.WriteLine("Enter ID : ");
                //var id = Convert.ToInt32(Console.ReadLine());
                //var student1 = context.Students.Find(id);
                //Console.WriteLine($"{student1.Name} {student1.Surname} - {student1.Email} - {student1.BirthDate}");

                //Student UpStu = context.Students.Find(1);

                //UpStu.Surname = "UpdatedSurname";
                //UpStu.Email = "qwqewq";
                //context.SaveChanges();

                Student studentToDelete = context.Students.Find(1004);

                context.Students.Remove(studentToDelete);
                context.SaveChanges();

                Console.WriteLine("Database connection successful.");
            }
            else
            {
                Console.WriteLine("Database connection failed.");
            }
        }
    }
}
