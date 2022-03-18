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
    public class LecturerDao : BaseDao
    {      
        public List<Lecturer> GetAllLecturers()
        {
            string query = "SELECT teacherID, name, roomID FROM teacher";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Lecturer> ReadTables(DataTable dataTable)
        {
            List<Lecturer> lecturers = new List<Lecturer>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Lecturer lecturer = new Lecturer()
                {
                    TeacherID = (int)dr["teacherID"],
                    Name = (string)(dr["name"].ToString()),
                    RoomID = (int)dr["roomID"],
                };
                lecturers.Add(lecturer);
            }
            return lecturers;
        }
    }
}
