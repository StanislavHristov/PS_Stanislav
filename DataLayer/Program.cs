using DataLayer.Database;
using DataLayer.Model;
using System.Data;
using System.Xml.Linq;
using Welcome.Others;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                /*context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = UserRolesEnum.STUDENT
                });
                context.SaveChanges();
                var users = context.Users.ToList(); Console.ReadKey();*/
                DatabaseMenu.Menu();
                var loggers = context.LogEntries.ToList();
                foreach (var log in loggers)
                {
                    Console.WriteLine($"Logger: [{log.Id}], [{log.Message}], [{log.CreatedAt}]");
                }
            }
        }
    }
}
