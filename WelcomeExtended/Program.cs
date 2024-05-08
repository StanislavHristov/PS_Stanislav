using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;

namespace WelcomeExtended
{
    internal class Program
    {
        private static int eventId = 0;
        static void Main(string[] args)
        {
            ILogger successfulLogger = new FileLogger(@"C:\Users\Stanislav\Documents\PS_43_Stanislav\PS_43_Stanislav\
            WelcomeExtended\Resources\successfullyLogInUsers.txt");
            ILogger unsuccessfulLogger = new FileLogger(@"C:\Users\Stanislav\Documents\PS_43_Stanislav\PS_43_Stanislav\
            WelcomeExtended\Resources\unsuccessfullyLogInUsers.txt");
            UserData userData = new();
            User studentUser = new()
            {
                Name = "student",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            userData.AddUser(studentUser);
            User studentUser1 = new()
            {
                Name = "Student2",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            userData.AddUser(studentUser1);
            User teacherUser = new()
            {
                Name = "Teacher",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR
            };
            userData.AddUser(teacherUser);
            User adminUser = new()
            {
                Name = "Admin",
                Password = "12345",
                Role = UserRolesEnum.ADMIN
            };
            userData.AddUser(adminUser);

            string name, password;
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            password = Console.ReadLine();
            password = User.password;
            int res = UserHelper.ValidateCredentials(userData, name, password);
            switch (res)
            {
                case 1:
                    User currUser = UserHelper.GetUser(userData, name, password);
                    Console.WriteLine(UserHelper.ToString(currUser));
                    successfulLogger.Log(LogLevel.Information, new EventId(eventId++), $"User {name} logged in successfully.", null, (state, exception) => state.ToString());
                    break;
                case 0:
                    LoggerHelper.UnsuccessfulLogin(unsuccessfulLogger, eventId++, "The name cannot be empty!");
                    break;
                case 2:
                    LoggerHelper.UnsuccessfulLogin(unsuccessfulLogger, eventId++, "The password cannot be empty!");
                    break;
                case 3:
                    LoggerHelper.UnsuccessfulLogin(unsuccessfulLogger, eventId++, "User not found!");
                    break;
            }
        }
    }
}
