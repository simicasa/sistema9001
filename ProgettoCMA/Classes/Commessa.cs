using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Commessa
    {
        public Commessa(int ID, Cliente cliente, String codice, Utente utente, String note) : this()
        {
            this.ID = ID;
            this.Chiusura = "";
            this.Cliente = cliente;
            this.Codice = codice;
            this.Creazione = DateTime.Now.ToShortDateString();
            this.RDO = new HashSet<RDO>();
            this.Utente = utente;
            this.Note = note;
        }
        public override string ToString()
        {
            return (this.Cliente.ID 
                + " - " + this.Utente.ID + " - " + 
                this.RDO.Count().ToString());
        }
    }
}
