using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Associazione_Categoria_Fornitore
    {
        public Associazione_Categoria_Fornitore()
        {

        }
        public Associazione_Categoria_Fornitore(Fornitore fornitore, Categoria categoria)
        {
            this.Fornitore = fornitore;
            this.Categoria = categoria;
        }
        public static Associazione_Categoria_Fornitore Find(Fornitore fornitore, Categoria categoria)
        {
            IQueryable<Associazione_Categoria_Fornitore> acf = Shared.cdc.Associazione_Categoria_FornitoreSet.Where(a => a.Fornitore.ID == fornitore.ID && a.Categoria.ID == categoria.ID);
            if (acf.Count() != 1)
            {
                throw new Exception("Trovata piu' di una Associazione_Categoria_Fornitore");
            }
            return acf.First();
        }
    }
}

