using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Lista_RDO_Composizione
    {
        public Lista_RDO_Composizione(int ID, Lista_RDO listaRDO, Categoria categoriaMicro, string descrizione, decimal quantita, string unitaMisura)
        {
            this.ID = ID;
            this.Lista_RDO = listaRDO;
            this.Categoria = categoriaMicro;
            this.Descrizione = descrizione;
            this.Quantita = quantita;
            this.UnitaMisura = unitaMisura;
        }
    }
}
