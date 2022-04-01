using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {
                // hide all other panels
                pnlStudents.Hide();
                pnlLecturers.Hide();
                pnlDrinks.Hide();
                pnlActivities.Hide();

                // show dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlActivities.Hide();

                // show students
                pnlStudents.Show();

                try
                {
                    // fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents(); ;
                    
                    // clear the listview before filling it again
                    listViewStudents.Clear();
                    listViewStudents.View = View.Details;
                    listViewStudents.FullRowSelect = true;
                    listViewStudents.Columns.Add("StudentID");
                    listViewStudents.Columns.Add("Name" );
                    listViewStudents.Columns.Add("BirthDate");
                    listViewStudents.Columns.Add("RoomID");

                    foreach (Student s in studentList)
                    {
                        string[] row = { s.StudentID.ToString(), s.Name ,s.BirthDate.ToShortDateString(),s.RoomID.ToString()};
                        ListViewItem li = new ListViewItem(row);
                        listViewStudents.Items.Add(li);                        
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }
            else if (panelName == "Lecturers")
            {
                // hide all other panels
                pnlDashboard.Hide();
                pnlStudents.Hide();
                pnlDrinks.Hide();
                pnlActivities.Hide();

                // show students
                pnlLecturers.Show();

                try
                {
                    // fill the lecturers listview within the lecturers panel with a list of lecturers
                    LecturerService lectService = new LecturerService(); ;
                    List<Lecturer> lecturerList = lectService.GetLecturers(); ;

                    // clear the listview before filling it again
                    listViewLecturers.Clear();
                    listViewLecturers.View = View.Details;
                    listViewLecturers.FullRowSelect = true;
                    listViewLecturers.Columns.Add("TeacherID");
                    listViewLecturers.Columns.Add("Name");
                    listViewLecturers.Columns.Add("RoomID");

                    foreach (Lecturer s in lecturerList)
                    {
                        string[] row = { s.TeacherID.ToString(), s.Name, s.RoomID.ToString() };
                        ListViewItem li = new ListViewItem(row);
                        listViewLecturers.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the lecturers: " + e.Message);
                }
            }
            else if (panelName == "Drinks")
            {
                // hide all other panels
                pnlDashboard.Hide();
                pnlStudents.Hide();
                pnlLecturers.Hide();
                pnlActivities.Hide();

                // show students
                pnlDrinks.Show();

                try
                {
                    // fill the lecturers listview within the lecturers panel with a list of lecturers
                    DrinksService drinkService = new DrinksService(); ;
                    List<Drink> drinksList = drinkService.GetDrinks(); ;

                    // clear the listview before filling it again
                    listViewDrinks.Clear();
                    listViewDrinks.View = View.Details;
                    listViewDrinks.FullRowSelect = true;
                    listViewDrinks.Columns.Add("Drink ID");
                    listViewDrinks.Columns.Add("Name");
                    listViewDrinks.Columns.Add("Is Alcoholic");
                    listViewDrinks.Columns.Add("Price");
                    listViewDrinks.Columns.Add("VAT");
                    listViewDrinks.Columns.Add("Stock");
                    listViewDrinks.Columns.Add("Sufficient Stock");

                    //columns appearance
                    for (int i = 0; i < listViewDrinks.Columns.Count; i++)
                    {
                        listViewDrinks.Columns[i].Width = 80;
                        listViewDrinks.Columns[i].TextAlign = HorizontalAlignment.Center;
                    }
                    listViewDrinks.Columns[6].Width = 130;

                    string sufficientStock = "";
                    foreach (Drink s in drinksList)
                    {
                        if (s.SufficientStock)
                            sufficientStock = "Stock sufficient";
                        else
                            sufficientStock = "Stock nearly depleted";

                        string[] row = { s.DrinkID.ToString(), s.Name, s.IsAlcoholic.ToString(), s.Price.ToString(), s.Vat.ToString(), s.Stock.ToString(), sufficientStock };
                        ListViewItem li = new ListViewItem(row);
                        listViewDrinks.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
                }
            }
            else if (panelName == "Activities")
            {
                // hide all other panels
                pnlDashboard.Hide();
                pnlStudents.Hide();
                pnlLecturers.Hide();
                pnlDrinks.Hide();
                // show activites
                pnlActivities.Show();

                try
                {
                    // fill the lecturers listview within the lecturers panel with a list of lecturers
                    ActivitiesService activityService = new ActivitiesService(); ;
                    List<Activity> activitiesList = activityService.GetActivities(); ;

                    // clear the listview before filling it again
                    listViewActivities.Clear();
                    listViewActivities.View = View.Details;
                    listViewActivities.FullRowSelect = true;
                    listViewActivities.Columns.Add("Activity ID");
                    listViewActivities.Columns.Add("Name");
                    listViewActivities.Columns.Add("Date");
                    listViewActivities.Columns.Add("Start Time");
                    listViewActivities.Columns.Add("End Time");
                    
                    //columns appearance
                    for (int i = 0; i < listViewActivities.Columns.Count; i++)
                    {
                        listViewActivities.Columns[i].Width = 80;
                        listViewActivities.Columns[i].TextAlign = HorizontalAlignment.Center;
                    }
                    
                    foreach (Activity s in activitiesList)
                    {
                        string[] row = { s.ActivityID.ToString(), s.Name.ToString(), s.Date.ToString("d"), s.StartTime.ToString("t"), s.EndTime.ToString("t") };
                        ListViewItem li = new ListViewItem(row);
                        listViewActivities.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
                }
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imgDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }
        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks");
        }

        #region DRINKS
        //Create a drink object based on user input
        private Drink CreateDrink()
        {
            Drink drink = new Drink();
            drink.Name = textBoxName.Text;
            drink.Price = double.Parse(textBoxPrice.Text);
            drink.Vat = double.Parse(textBoxVat.Text);
            drink.Stock = int.Parse(textBoxStock.Text);
            drink.IsAlcoholic = IsAlc();
            return drink;
        }

        private bool IsAlc()
        {
            if (comboBoxIsAlcoholic.Text == "Alcoholic")
                return true;
            else
                return false;
        }

        //Select a row
        private void listViewDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                if (listViewDrinks.SelectedItems.Count != 0)
                {
                    textBoxName.Text = listViewDrinks.SelectedItems[0].SubItems[1].Text;
                    textBoxPrice.Text = listViewDrinks.SelectedItems[0].SubItems[3].Text;
                    textBoxVat.Text = listViewDrinks.SelectedItems[0].SubItems[4].Text;
                    if (listViewDrinks.SelectedItems[0].SubItems[2].Text == "True")
                        comboBoxIsAlcoholic.Text = "Alcoholic";
                    else if (listViewDrinks.SelectedItems[0].SubItems[2].Text == "False")
                        comboBoxIsAlcoholic.Text = "Not Alcoholic";
                    textBoxStock.Text = listViewDrinks.SelectedItems[0].SubItems[5].Text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Add a drink
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DrinksService drinks = new DrinksService();
            drinks.AddDrink(CreateDrink());
            showPanel("Drinks");
            MessageBox.Show("Drink Added Succesfully!");
        }

        //Delete a drink
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DrinksService drinks = new DrinksService();
            drinks.DeleteDrink(CreateDrink());
            showPanel("Drinks");
            MessageBox.Show("Drink Deleted Succesfully!");
        }

        //Modify an drink
        private void buttonModify_Click(object sender, EventArgs e)
        {
            DrinksService drinks = new DrinksService();
            int drinkID = Convert.ToInt32(listViewDrinks.SelectedItems[0].SubItems[0].Text);
            Drink drink = CreateDrink();
            drink.DrinkID = drinkID;
            drinks.ModifyDrink(drink);
            showPanel("Drinks");
            MessageBox.Show("Drink Modified Succesfully");
        }

        //Clear all the text
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxPrice.Clear();
            textBoxVat.Clear();
            comboBoxIsAlcoholic.Text = "Not Alcoholic";
            textBoxStock.Clear();
        }
        #endregion

        #region ACTIVITIES

        //Select a row
        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewActivities.SelectedItems.Count != 0)
                {
                    textBoxNameActivity.Text = listViewActivities.SelectedItems[0].SubItems[1].Text;
                    dateTimePickerDateActivity.Text = listViewActivities.SelectedItems[0].SubItems[2].Text;
                    dateTimePickerStartTimeActivity.Text = listViewActivities.SelectedItems[0].SubItems[3].Text;
                    dateTimePickerEndTimeActivity.Text = listViewActivities.SelectedItems[0].SubItems[4].Text;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Create an activity based on user input
        private Activity CreateActivity()
        {
            Activity activity = new Activity();
            activity.Name = textBoxNameActivity.Text;
            activity.Date = dateTimePickerDateActivity.Value;
            activity.StartTime = dateTimePickerStartTimeActivity.Value;
            activity.EndTime = dateTimePickerEndTimeActivity.Value;
            return activity;
        }

        //Add an activity
        private void buttonAddActivity_Click(object sender, EventArgs e)
        {
            ActivitiesService activities = new ActivitiesService();
            activities.AddActivity(CreateActivity());
            showPanel("Activities");
            MessageBox.Show("Activity Added Succesfully!1");
        }

        //Delete an activity
        private void buttonDeleteActivity_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("Are you sure you wish to remove this activity?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ActivitiesService activities = new ActivitiesService();
                activities.DeleteActivity(CreateActivity());
                showPanel("Activities");
                MessageBox.Show("Activity Deleted Succesfully!");
            }
        }

        //Modify an activity
        private void buttonModifyActivity_Click(object sender, EventArgs e)
        {
            ActivitiesService activities = new ActivitiesService();
            int activityID = Convert.ToInt32(listViewActivities.SelectedItems[0].SubItems[0].Text);
            Activity activity = CreateActivity();
            activity.ActivityID = activityID;
            activities.ModifyActivity(activity);
            showPanel("Activities");
            MessageBox.Show("Activity Modified Succesfully");
        }

        //CLear all the text
        private void buttonClearAllActivities_Click(object sender, EventArgs e)
        {
            textBoxNameActivity.Clear();
        }

        #endregion
    }
}
