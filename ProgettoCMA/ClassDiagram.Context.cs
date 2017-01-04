﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClassDiagramContainer : DbContext
    {
        public ClassDiagramContainer()
            : base("name=ClassDiagramContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Utente> UtenteSet { get; set; }
        public virtual DbSet<Commessa> CommessaSet { get; set; }
        public virtual DbSet<Ruolo> RuoloSet { get; set; }
        public virtual DbSet<RDO> RDOSet { get; set; }
        public virtual DbSet<RDO_Composizione> RDO_ComposizioneSet { get; set; }
        public virtual DbSet<ODA_Composizione> ODA_ComposizioneSet { get; set; }
        public virtual DbSet<ODA> ODASet { get; set; }
        public virtual DbSet<Categoria> CategoriaSet { get; set; }
        public virtual DbSet<Associazione_Categoria_Fornitore> Associazione_Categoria_FornitoreSet { get; set; }
        public virtual DbSet<Ordine_Composizione> Ordine_ComposizioneSet { get; set; }
        public virtual DbSet<Ordine> OrdineSet { get; set; }
        public virtual DbSet<Offerta> OffertaSet { get; set; }
        public virtual DbSet<Offerta_Composizione> Offerta_ComposizioneSet { get; set; }
        public virtual DbSet<Associazione_Offerta_Servizio> Associazione_Offerta_ServizioSet { get; set; }
        public virtual DbSet<Metodo_Pagamento> Metodo_PagamentoSet { get; set; }
        public virtual DbSet<Metodo_Spedizione> Metodo_SpedizioneSet { get; set; }
        public virtual DbSet<Servizio> ServizioSet { get; set; }
        public virtual DbSet<Contatto> ContattoSet { get; set; }
        public virtual DbSet<Azienda> AziendaSet { get; set; }
        public virtual DbSet<Lista_RDO_Composizione> Lista_RDO_ComposizioneSet { get; set; }
        public virtual DbSet<Lista_RDO> Lista_RDOSet { get; set; }
    }
}
