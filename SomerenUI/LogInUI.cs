using SomerenLogic;
using SomerenModel;
using Hashing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SomerenUI
{
    public partial class LogInUI : Form
    {
        public LogInUI()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            List<User> userList = userService.GetUsers();
            int index = userList.FindIndex(user => user.Username == textBoxUsername.Text);
            if (index >= 0)
            {
                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();

                if (pwHasher.HashWithUserSalt(textBoxPassword.Text, userList[index].Password, userList[index].Salt, SHA512.Create()))
                {
                    MessageBox.Show("Login successful");
                    this.Hide();
                    SomerenUI somerenUI = new SomerenUI();
                    somerenUI.Show();
                   

                } else
                {
                    MessageBox.Show("Incorrect password.");
                }
            } else
            {
                MessageBox.Show("User does not exist");
            }

        }
    }

}
