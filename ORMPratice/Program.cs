using Microsoft.EntityFrameworkCore;
using ORMPratice.Entities;

namespace ORMPratice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new Contexts.UniversityDb();
            //context.Database.Migrate(); => This line is used to apply any pending migrations to the database. It ensures that the database schema is up-to-date with the current model defined in the code. If there are any migrations that have not been applied yet, this method will execute them and update the database accordingly.

            bool isConnected = context.Database.CanConnect();
            if(isConnected)
            {
                Console.WriteLine("Database connection successful.");
            }
            else
            {
                Console.WriteLine("Database connection failed.");
            }
        }
    }
}
