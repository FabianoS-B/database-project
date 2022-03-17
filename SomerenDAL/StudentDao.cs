using System;
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
    public class StudentDao : BaseDao
    {      
        public List<Student> GetAllStudents()
        {
            string query = "select studentID, roomID, Birthdate, name from student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    StudentID = (int)dr["studentID"],
                    Name = (string)(dr["name"].ToString()),
                    RoomID = (int)dr["RoomID"],
                    BirthDate = (DateTime)dr["BirthDate"],
                    
                };
                students.Add(student);
            }
            return students;
        }
    }
}
