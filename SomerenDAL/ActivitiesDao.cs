using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;
using System.Windows.Forms;

namespace SomerenDAL
{
    public class ActivitiesDao : BaseDao
    {      
        public List<Activity> GetAllActivities()
        {
            string query = "SELECT activityID, name, date, startTime, endTime FROM activity";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // some comment
        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    ActivityID = (int)dr["activityID"],
                    Name = (string)dr["name"],
                    Date = (DateTime)dr["date"],
                    StartTime = (DateTime)dr["startTime"],
                    EndTime = (DateTime)dr["endTime"],
                };
                activities.Add(activity);
            }
            return activities;
        }
        
        //Add activity
        public void AddActivity(Activity activity)
        {
            string query = "INSERT INTO activity VALUES(@name, @date, @startTime, @endTime)";
            SqlParameter[] sqlParameters = { new SqlParameter("@name", activity.Name),  new SqlParameter("@date", activity.Date), new SqlParameter("@startTime", activity.StartTime), new SqlParameter("@endTime", activity.EndTime) };
            ExecuteEditQuery(query, sqlParameters);
        }

        //Delete activity
        public void DeleteDrink(Activity activity)
        {
            string query = "DELETE FROM activity WHERE [name]=@name";
            SqlParameter[] sqlParameters = { new SqlParameter("@name", activity.Name), new SqlParameter("@date", activity.Date), new SqlParameter("@startTime", activity.StartTime), new SqlParameter("@endTime", activity.EndTime) };
            ExecuteEditQuery(query, sqlParameters);
        }

        //Modify activity
        public void ModifyDrink(Activity activity)
        {
            string query = "UPDATE activity SET [name]=@name, date=@date, startTime=@startTime, endTime=@endTime WHERE activityID=@activityID";
            SqlParameter[] sqlParameters = { new SqlParameter("activityID", activity.ActivityID), new SqlParameter("@name", activity.Name), new SqlParameter("@date", activity.Date), new SqlParameter("@startTime", activity.StartTime), new SqlParameter("@endTime", activity.EndTime) };
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
