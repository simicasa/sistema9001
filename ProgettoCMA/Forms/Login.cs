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
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Shared.utente = this.checkLogin(usernameTextBox.Text, passwordTextBox.Text);
            if (Shared.utente != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private Utente checkLogin(String username, String password)
        {
            IQueryable<Utente> utente = Shared.cdc.UtenteSet.Where(u => u.Username == username && u.Password == password);
            if (utente.Count() == 1)
            {
                return utente.First();
            }
            return null;
        }
    }
}
