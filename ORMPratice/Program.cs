using Microsoft.EntityFrameworkCore;
using ORMPratice.Contexts;
using ORMPratice.Entities;
using ORMPratice.Services;


namespace ORMPratice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new UniversityDb();
            context.Database.Migrate();
            GroupService groupService = new GroupService();
            StudentService studentService = new StudentService();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== UNİVERSİTET İDARƏETMƏ SİSTEMİ ===");
                Console.WriteLine("1. Qrupları idarə et");
                Console.WriteLine("2. Tələbələri idarə et");
                Console.WriteLine("0. Çıxış");
                Console.Write("Seçiminizi edin: ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        GroupMenu(groupService);
                        break;
                    case "2":
                        StudentMenu(studentService);
                        break;
                    case "0":
                        Console.WriteLine("Proqramdan çıxılır...");
                        return;
                    default:
                        Console.WriteLine("Yanlış seçim! Davam etmək üçün hər hansı bir düyməyə basın.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GroupMenu(GroupService groupService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- QRUP MENYUSU ---");
                Console.WriteLine("1. Qrup əlavə et");
                Console.WriteLine("2. Qrupa düzəliş et");
                Console.WriteLine("3. Qrupu sil");
                Console.WriteLine("4. Bütün qruplara bax");
                Console.WriteLine("5. ID-yə görə qrup axtar");
                Console.WriteLine("6. Ada görə qrup axtar");
                Console.WriteLine("7. Qrupdakı tələbələrə bax");
                Console.WriteLine("0. Ana menyuya qayıt");
                Console.Write("Seçiminizi edin: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Qrup adı: ");
                        string name = Console.ReadLine();
                        Console.Write("Tələbə limiti: ");
                        if (int.TryParse(Console.ReadLine(), out int limit))
                        {
                            Group newGroup = new Group { Name = name, Limit = limit };
                            groupService.AddGroup(newGroup);
                        }
                        else Console.WriteLine("Limit üçün düzgün rəqəm daxil edin.");
                        break;

                    case "2":
                        Console.Write("Düzəliş etmək istədiyiniz qrupun ID-si: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Group groupToUpdate = groupService.GetGroupById(updateId);
                            if (groupToUpdate != null)
                            {
                                Console.Write("Yeni qrup adı: ");
                                string newName = Console.ReadLine();
                                Console.Write("Yeni limit: ");
                                if (int.TryParse(Console.ReadLine(), out int newLimit))
                                {
                                    groupService.UpdateGroup(groupToUpdate, newName, newLimit);
                                }
                                else Console.WriteLine("Limit üçün düzgün rəqəm daxil edin.");
                            }
                        }
                        else Console.WriteLine("Düzgün ID daxil edin.");
                        break;

                    case "3":
                        Console.Write("Silmək istədiyiniz qrupun ID-si: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Group groupToDelete = groupService.GetGroupById(deleteId);
                            if (groupToDelete != null)
                            {
                                groupService.DeleteGroup(groupToDelete);
                            }
                        }
                        else Console.WriteLine("Düzgün ID daxil edin.");
                        break;

                    case "4":
                        Console.WriteLine("--- Bütün Qruplar ---");
                        groupService.GetAllGroups();
                        break;

                    case "5":
                        Console.Write("Axtarılan qrupun ID-si: ");
                        if (int.TryParse(Console.ReadLine(), out int searchId))
                        {
                            groupService.GetGroupById(searchId);
                        }
                        else Console.WriteLine("Düzgün ID daxil edin.");
                        break;

                    case "6":
                        Console.Write("Axtarılan qrupun Adı: ");
                        string searchName = Console.ReadLine();
                        groupService.SearchByName(searchName);
                        break;

                    case "7":
                        Console.Write("Tələbələrini görmək istədiyiniz qrupun ID-si: ");
                        if (int.TryParse(Console.ReadLine(), out int groupId))
                        {
                            groupService.GetStudentsByGroupId(groupId);
                        }
                        else Console.WriteLine("Düzgün ID daxil edin.");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Yanlış seçim!");
                        break;
                }
                Console.WriteLine("\nDavam etmək üçün hər hansı bir düyməyə basın...");
                Console.ReadKey();
            }
        }

        static void StudentMenu(StudentService studentService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- TƏLƏBƏ MENYUSU ---");
                Console.WriteLine("1. Tələbə əlavə et");
                Console.WriteLine("2. Tələbəyə düzəliş et");
                Console.WriteLine("3. Tələbəni sil");
                Console.WriteLine("4. Bütün tələbələrə bax");
                Console.WriteLine("5. ID-yə görə tələbə axtar");
                Console.WriteLine("6. Ada görə tələbə axtar");
                Console.WriteLine("0. Ana menyuya qayıt");
                Console.Write("Seçiminizi edin: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ad: ");
                        string name = Console.ReadLine();
                        Console.Write("Soyad: ");
                        string surname = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Grup ID: ");
                        int groupID = int.Parse(Console.ReadLine());
                        // Əgər Entity-də GroupId varsa, bura uyğunlaşdıra bilərsiniz.
                        // Metodlarınızda string tipində qəbul etdiyinizə görə belə saxlayırıq.

                        Student newStudent = new Student
                        {
                            Name = name,
                            Surname = surname,
                            Email = email,
                            GroupId = groupID
                        };
                        studentService.AddStudent(newStudent);
                        break;

                    case "2":
                        Console.Write("Düzəliş etmək istədiyiniz tələbənin ID-si: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Student studentToUpdate = studentService.GetStudentById(updateId);
                            if (studentToUpdate != null)
                            {
                                Console.Write("Yeni Ad: ");
                                string newName = Console.ReadLine();
                                Console.Write("Yeni Soyad: ");
                                string newSurname = Console.ReadLine();
                                Console.Write("Yeni Email: ");
                                string newEmail = Console.ReadLine();
                                Console.Write("Yeni Qrup (mətn olaraq): ");
                                int newGroup = int.Parse(Console.ReadLine());

                                studentService.UpdateStudent(studentToUpdate,newName,newEmail,newGroup,newSurname);
                            }
                        }
                        else Console.WriteLine("Düzgün ID daxil edin.");
                        break;

                    case "3":
                        Console.Write("Silmək istədiyiniz tələbənin ID-si: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Student studentToDelete = studentService.GetStudentById(deleteId)!;
                            if (studentToDelete != null)
                            {
                                studentService.DeleteStudent(studentToDelete);
                            }
                        }
                        else Console.WriteLine("Düzgün ID daxil edin.");
                        break;

                    case "4":
                        Console.WriteLine("--- Bütün Tələbələr ---");
                        studentService.GetAllStudents();
                        break;

                    case "5":
                        Console.Write("Axtarılan tələbənin ID-si: ");
                        if (int.TryParse(Console.ReadLine(), out int searchId))
                        {
                            studentService.GetStudentById(searchId);
                        }
                        else Console.WriteLine("Düzgün ID daxil edin.");
                        break;

                    case "6":
                        Console.Write("Axtarılan tələbənin Adı: ");
                        string searchName = Console.ReadLine();
                        studentService.SearchByName(searchName);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Yanlış seçim!");
                        break;
                }
                Console.WriteLine("\nDavam etmək üçün hər hansı bir düyməyə basın...");
                Console.ReadKey();
            }
        }
    }
}
