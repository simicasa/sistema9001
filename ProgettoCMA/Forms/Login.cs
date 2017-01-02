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
        private Home home;

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
            Shared.utente = this.checkLogin(usernameTextBox.Text, passwordTextBox.Text);
            if (Shared.utente != null)
            {
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
            /*
            var res = from user in cdc.UtenteSet
                      where user.Username == username && user.Password == password
                      select user;
            try
            {
                if (res.Count() > 0)
                {
                    Console.WriteLine("tappost");
                    return res.First();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("nientaappost");
            return null;
            */
        }
    }
}
