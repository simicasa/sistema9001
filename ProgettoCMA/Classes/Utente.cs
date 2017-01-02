using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Utente
    {
        public Utente(String nome, String cognome, String username, int ID, Ruolo ruolo = null)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.Username = username;
            this.ID = ID;
            this.Ruolo = new Ruolo("prova");
            //this.Ruolo = (ruolo == null) ? new Ruolo() : ruolo;
        }
        public Utente(String nome, String cognome, String username, int ID, String password, Ruolo ruolo = null) : this(nome, cognome, username, ID, ruolo)
        {
            this.Password = password;
        }
        /*
        public override string ToString()
        {
            return this.Nome + " " + this.Cognome + " " + this.Username + " " + this.ID.ToString() + this.Ruolo.ID.ToString();
        }
        */
    }
}
