using IsTakipSistemiMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IsTakipSistemiMvc.Models
{

    public class IsTakipContext : DbContext
    {
        public IsTakipContext() : base("name=IsTakipContext")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<IsTakipContext>()
            );

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }



        // 2. BU METODU EKLE (Tablo isimlerine karışma demektir)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Is> Isler { get; set; }
        public DbSet<Durum> Durumlar { get; set; }
        public DbSet<YetkiTur> YetkiTurler { get; set; }
    }
}



