using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class RDO_Composizione
    {
        public RDO_Composizione(int ID, Lista_RDO_Composizione listaRDOComposizione, RDO rdo)
        {
            this.ID = ID;
            this.Lista_RDO_Composizione = listaRDOComposizione;
            this.RDO = rdo;
        }
    }
}
