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
    
    public partial class Contatto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contatto()
        {
            this.Azienda = new HashSet<Azienda>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Descrizione { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Azienda> Azienda { get; set; }
    }
}
