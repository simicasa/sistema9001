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
    
    public partial class Commessa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commessa()
        {
            this.Lista_RDO = new HashSet<Lista_RDO>();
        }
    
        public int ID { get; set; }
        public string Codice { get; set; }
        public string Creazione { get; set; }
        public string Chiusura { get; set; }
        public string Note { get; set; }
    
        public virtual Utente Utente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lista_RDO> Lista_RDO { get; set; }
    }
}
