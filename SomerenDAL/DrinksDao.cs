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
    public class DrinksDao : BaseDao
    {      
        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT drinkID, name, isAlcoholic, price, vat, stock FROM drink ORDER BY name";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // some comment
        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    DrinkID = (int)dr["drinkID"],
                    Name = (string)dr["name"],
                    IsAlcoholic = (bool)dr["isAlcoholic"],
                    Price = (double)dr["price"],                    
                    Vat = (double)dr["vat"],                    
                    Stock = (int)dr["stock"],                    
                };
                drinks.Add(drink);
            }
            return drinks;
        }

        // INSERT
        private void InsertDrink()
        {

        }

        private void UpdateDrink()
        {

        }

        private void DeleteDrink()
        {

        }
    }
}
