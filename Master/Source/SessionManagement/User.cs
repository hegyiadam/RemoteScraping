using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.UserHandling
{
    public class User
    {
        public User(string username)
        {
            UserName = username;
        }
        public string UserName { get; }
    }
}
