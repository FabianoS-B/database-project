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
    public class DrinksService
    {
        DrinksDao drinksdb;

        public DrinksService()
        {
            drinksdb = new DrinksDao();
        }

        public List<Drink> GetDrinks()
        {
            List<Drink> drinks = drinksdb.GetAllDrinks();
            return drinks;
        }

        // crear y modificar
        public void SaveDrink(Drink drink)
        {

        }

        public void DeleteDrink(Drink drink)
        {

        }

        public void InsertDrink(Drink drink) => drinksdb.InsertDrink(drink);
    }
}
