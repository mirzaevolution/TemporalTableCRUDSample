using MirzaCryptoHelpers.Hashings;
using MSC.BussinessLogics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSC
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TextBoxUserName.Text) || string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                MessageBox.Show("Please complete all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                HandleLogin(TextBoxUserName.Text, TextBoxPassword.Text);
            }
        }
        private void HandleLogin(string username, string password)
        {
            string hashedPwd = new SHA256Crypto().GetHashBase64String(password);
            UsersBLL usersBLL = new UsersBLL();
            var result = usersBLL.Login(username, password);
            if(result.Granted)
            {
                CoreGlobal.LoggedUser = result.UserName;
                this.Hide();
                new FormMain().Show();
            }
            else
            {
                MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
