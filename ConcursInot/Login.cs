using System;
using System.Windows.Forms;
using ConcursInot.client;

namespace ConcursInot
{
    partial class Login : Form
    {
        ClientCtrl proxy;

        public Login(ClientCtrl proxy)
        {
            this.proxy = proxy;
            InitializeComponent();
        }

          

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var user = userTextBox.Text;
            var password = passwordTextBox.Text;
            
            if (proxy.Login(user, password))
            {
                MainWindow mainWindow = new MainWindow(this, proxy);
                proxy.SetMainWindow(mainWindow);
                this.Hide();
                labelValidate.Text = "";
                userTextBox.Text = "";
                passwordTextBox.Text = "";
                mainWindow.Show();
            }
            else
            {
                labelValidate.Text = "INVALID";
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            //passwordTextBox.UseSystemPasswordChar = 'a';
            passwordTextBox.UseSystemPasswordChar = false;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
