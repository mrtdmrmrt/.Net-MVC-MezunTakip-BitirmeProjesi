namespace MvcTakip.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mvcTakipDB : DbContext
    {
        public mvcTakipDB()
            : base("name=mvcTakipDB")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblBolum> tblBolums { get; set; }
        public virtual DbSet<tblKisi> tblKisis { get; set; }
        public virtual DbSet<tblYetki> tblYetkis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBolum>()
                .HasMany(e => e.tblKisis)
                .WithOptional(e => e.tblBolum)
                .HasForeignKey(e => e.BolumId);

            modelBuilder.Entity<tblYetki>()
                .HasMany(e => e.tblKisis)
                .WithOptional(e => e.tblYetki)
                .HasForeignKey(e => e.YetkiId);
        }
    }
}
