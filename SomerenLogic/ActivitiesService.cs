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
    public class ActivitiesService
    {
        ActivitiesDao activitiesdb;

        public ActivitiesService()
        {
            activitiesdb = new ActivitiesDao();
        }

        public List<Activity> GetActivities()
        {
            List<Activity> activities = activitiesdb.GetAllActivities();
            return activities;
        }
        
        //Delete drink
        public void DeleteActivity(Activity activity)
        {
            activitiesdb.DeleteActivity(activity);
        }
        
        //Add activity
        public void AddActivity(Activity activity)
        {
            activitiesdb.AddActivity(activity);
        }

        //Modify activity
        public void ModifyActivity(Activity activity)
        {
            activitiesdb.ModifyActivity(activity);
        }
    }
}
