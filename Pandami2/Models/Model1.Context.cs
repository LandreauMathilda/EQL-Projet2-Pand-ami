﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pandami2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pandamidbEntities : DbContext
    {
        public pandamidbEntities()
            : base("name=pandamidbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categorie> categorie { get; set; }
        public virtual DbSet<demande_service> demande_service { get; set; }
        public virtual DbSet<equipement> equipement { get; set; }
        public virtual DbSet<genre> genre { get; set; }
        public virtual DbSet<motif_desinscription> motif_desinscription { get; set; }
        public virtual DbSet<type_service> type_service { get; set; }
        public virtual DbSet<utilisateur> utilisateur { get; set; }
        public virtual DbSet<ville> ville { get; set; }
    }
}
