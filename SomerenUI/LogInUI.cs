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
    public partial class LogInUI : Form
    {
        public LogInUI()
        {
            InitializeComponent();
        }

        //Create a user based on user input
        private User CreateActivity()
        {
            User user = new User();
            user.Username = textBoxUsername.Text;
            user.Password = textBoxPassword.Text;
            return user;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            UserService users = new UserService();
            User user = CreateActivity();
        }
    }
}
