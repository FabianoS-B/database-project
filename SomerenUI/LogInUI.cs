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

        //Create a user based on user input
        private User CreateUser()
        {
            PasswordWithSaltHasher hasher = new PasswordWithSaltHasher();
            User user = new User();
            user.Username = textBoxUsername.Text;
            user.Password = hasher.HashWithSalt(textBoxPassword.Text, 64, SHA256.Create()).ToString();
            return user;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            UserService users = new UserService();
            User user = CreateUser();
        }
    }

}
