using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class RDO
    {
        public RDO(int ID, Lista_RDO listaRDO, string codice, string creazione, string progressivo) : this()
        {
            this.ID = ID;
            this.Lista_RDO = listaRDO;
            this.Codice = codice;
            this.Creazione = creazione;
            this.Progressivo = progressivo;
        }
    }
}
