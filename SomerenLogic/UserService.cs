using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class UserService
    {
        UserDao usersdb;

        public UserService()
        {
            usersdb = new UserDao();
        }

        public List<User> GetUsers()
        {
            List<User> users = usersdb.GetAllUsers();
            return users;
        }
    }
}
