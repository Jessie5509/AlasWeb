﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlasPUMEntities : DbContext
    {
        public AlasPUMEntities()
            : base("name=AlasPUMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Asiento> Asiento { get; set; }
        public virtual DbSet<Intercontinental> Intercontinental { get; set; }
        public virtual DbSet<Nacional> Nacional { get; set; }
        public virtual DbSet<Regional> Regional { get; set; }
        public virtual DbSet<Vuelo> Vuelo { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<Aeronave> Aeronave { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
    }
}
