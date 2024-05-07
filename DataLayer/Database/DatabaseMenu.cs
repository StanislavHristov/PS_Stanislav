using DataLayer.Model;
using DataLayer.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    internal class DatabaseMenu
    {
        public static void Menu()
        {
            using (var context = new DatabaseContext())
            {
                var logger = new LoggerToDB(context);
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("1. Get all users");
                    Console.WriteLine("2. Add new user");
                    Console.WriteLine("3. Delete user");
                    Console.WriteLine("4. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            GetAllUsers(context, logger);
                            break;
                        case "2":
                            AddUser(context, logger);
                            break;
                        case "3":
                            DeleteUser(context, logger);
                            break;
                        case "4":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Choose one of the options.");
                            break;
                    }
                }
            }
            static void GetAllUsers(DatabaseContext context, LoggerToDB logger)
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Role: {user.Role}, Email: {user.Email}");
                }
                logger.LogMessage("All users gotten!");
            }

            static void AddUser(DatabaseContext context, LoggerToDB logger)
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                Console.WriteLine("Enter fac num:");
                int FacultyNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter email:");
                string email = Console.ReadLine();

                var user = new DatabaseUser { Name = name, Password = password, FacultyNumber = FacultyNumber, Email = email };
                context.Users.Add(user);
                context.SaveChanges();

                Console.WriteLine("User added successfully.");
                logger.LogMessage($"The user has been added: {name}");
            }

            static void DeleteUser(DatabaseContext context, LoggerToDB logger)
            {
                Console.WriteLine("Enter ID of the user to delete:");
                int id = int.Parse(Console.ReadLine());

                var user = context.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    Console.WriteLine($"The user: {user.Name} with id: {id} has been deleted successfully.");
                    logger.LogMessage($"The user: {user.Name} with id: {id} has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"No user found with that ID: {id}");
                    logger.LogMessage($"The user with that ID: {id} couldn't be found!");
                }
            }
        }
    }
}
