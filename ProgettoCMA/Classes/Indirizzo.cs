using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Indirizzo
    {
        public Indirizzo()
        {
            this.Cap = "";
            this.Citta = "";
            this.Civico = "";
            this.Nazione = "";
            this.Provincia = "";
            this.Via = "";

        }
        public Indirizzo(String via, String civico, String citta, String provincia, String cap, String nazione)
        {
            this.Cap = cap;
            this.Citta = citta;
            this.Civico = civico;
            this.Nazione = nazione;
            this.Provincia = provincia;
            this.Via = via;
        }
    }
}
