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
        /*
        //Delete drink
        public void DeleteDrink(Drink drink)
        {
            drinksdb.DeleteDrink(drink);
        }
        
        //Add drink
        public void AddDrink(Drink drink)
        {
            drinksdb.AddDrink(drink);
        }

        //Modify drink
        public void ModifyDrink(Drink drink)
        {
            drinksdb.ModifyDrink(drink);
        } */
    }
}
