﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class UserDao : BaseDao
    {      
        public List<User> GetAllUsers()
        {
            string query = "SELECT userID, name, role, username, password FROM user";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // some comment
        private List<User> ReadTables(DataTable dataTable)
        {
            List<User> users = new List<User>();

            foreach (DataRow dr in dataTable.Rows)
            {
                User user = new User()
                {
                    UserID = (int)dr["userID"],
                    Name = (string)dr["name"],
                    Role = (string)dr["role"],
                    Username = (string)dr["username"],
                    Password = (string)dr["password"]
                };
                users.Add(user);
            }
            return users;
        }
    }
}
