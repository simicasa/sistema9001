//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgettoCMA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Associazione_Categoria_Fornitore
    {
        public int ID { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Fornitore Fornitore { get; set; }
    }
}
