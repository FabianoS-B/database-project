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

                    string sufficientStock = "";
                    foreach (Drink s in drinksList)
                    {
                        if (s.SufficientStock)
                            sufficientStock = "Sufficient Stock";
                        else
                            sufficientStock = "Insufficient Stock";

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

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks");
        }
    }
}
