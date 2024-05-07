using System.Reflection.Metadata;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "Stanislav Hristov";
            user.Password = "1234abcd";
            user.Role = Others.UserRolesEnum.ADMIN;
            user.FacultyNumber = 121212121;
            user.Email = "idk@gmail.com";

            UserViewModel viewModel = new UserViewModel(user);

            UserView userView = new UserView(viewModel);
            userView.Display();
        }
    }
}