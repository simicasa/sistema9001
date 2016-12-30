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
        public static Utente checkLogin(String username, String password)
        {
            ClassDiagramContainer cdc = new ClassDiagramContainer();
            IQueryable<Utente> utente = cdc.UtenteSet.Where(u => u.Username == username && u.Password == password);
            int count = utente.Count();
            if(count == 1)
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
