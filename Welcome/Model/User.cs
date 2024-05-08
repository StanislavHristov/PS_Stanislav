using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public virtual int Id {  get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public static string? password;
        public UserRolesEnum Role { get; set; }
        public int FacultyNumber { get; set; }
        public string? Email { get; set; }

    }
}
