using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Fornitore : Azienda
    {
        /*
        public Fornitore(int ID) : this()
        {
            this.ID = ID;
            this.CodFisc = "";
            this.Creazione = "";
            this.Indirizzo = new Indirizzo();
            this.Mail = "";
            this.Note = "";
            this.Piva = "";
            this.Ragione = "";
            this.Telefono = "";
        }
        */
        public Fornitore(int ID, String CF, Indirizzo indirizzo, String email, String note, String PIVA, String ragione, String telefono) : this()
        {
            this.ID = ID;
            this.CodFisc = CF;
            this.Creazione = DateTime.Now.ToShortDateString();
            this.Indirizzo = indirizzo;
            this.Mail = email;
            this.Note = note;
            this.Piva = PIVA;
            this.Ragione = ragione;
            this.Telefono = telefono;
        }
    }
}