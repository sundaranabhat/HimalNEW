﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HimalDbEntities : DbContext
    {
        public HimalDbEntities()
            : base("name=HimalDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LookupIdentifier> LookupIdentifiers { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileIdentifier> ProfileIdentifiers { get; set; }
        public virtual DbSet<Personnel> Personnels { get; set; }
        public virtual DbSet<Personnel1> Personnel1 { get; set; }
        public virtual DbSet<vPersonnel> vPersonnels { get; set; }
    }
}