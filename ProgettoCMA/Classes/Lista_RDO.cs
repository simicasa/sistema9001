using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Lista_RDO
    {
        public Lista_RDO(int ID, Commessa commessa, String condizioniParticolari, String progressivo, String creazione)
        {
            this.ID = ID;
            this.Commessa = commessa;
            this.CondizioniParticolari = condizioniParticolari;
            this.Progressivo = progressivo;
            this.Creazione = creazione;
        }
    }
}
