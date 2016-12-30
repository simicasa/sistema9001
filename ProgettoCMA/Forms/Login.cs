using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    public partial class Login : Form
    {
        public Home home;

        public Login(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.home.utente = Utente.checkLogin(usernameTextBox.Text, passwordTextBox.Text);
            if (this.home.utente != null)
            {
                this.Close();
            }
        }
    }
}
