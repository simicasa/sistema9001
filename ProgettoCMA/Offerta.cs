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
    
    public partial class Offerta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Offerta()
        {
            this.Offerta_Composizione = new HashSet<Offerta_Composizione>();
            this.Metodo_Pagamento = new HashSet<Metodo_Pagamento>();
            this.Metodo_Spedizione = new HashSet<Metodo_Spedizione>();
        }
    
        public int ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offerta_Composizione> Offerta_Composizione { get; set; }
        public virtual Ordine Ordine { get; set; }
        public virtual Associazione_Offerta_Servizio Associazione_Offerta_Servizio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Metodo_Pagamento> Metodo_Pagamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Metodo_Spedizione> Metodo_Spedizione { get; set; }
    }
}
