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
    
    public partial class ODA_Composizione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ODA_Composizione()
        {
            this.Ordine_Composizione = new HashSet<Ordine_Composizione>();
        }
    
        public int Id { get; set; }
    
        public virtual ODA ODA { get; set; }
        public virtual RDO_Composizione RDO_Composizione { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordine_Composizione> Ordine_Composizione { get; set; }
    }
}
