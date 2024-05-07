using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    static class UserHelper
    {
        public static string ToString(this User user)
        {
            return $"User Details:\nId: {user.Id}\nName: {user.Name}\nRole: {user.Role}" +
                $"\nFaculty Number: {user.FacultyNumber}\nEmail: {user.Email}";
        }
        public static int ValidateCredentials(UserData userData, string name, string password)
        {
            if (name.Equals(""))
            {
                return 0;
            }
            if (password.Equals(""))
            {
                return 2;
            }
            if (!userData.ValidateUser(name, password))
            {
                return 3;
            }
            return 1;
        }
        public static User GetUser(UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
