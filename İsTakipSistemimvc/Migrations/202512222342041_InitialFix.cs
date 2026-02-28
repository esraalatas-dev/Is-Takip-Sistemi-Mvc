namespace IsTakipSistemiMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personel", "AdSoyad", c => c.String(nullable: false));
            AlterColumn("dbo.Personel", "KullaniciAd", c => c.String(nullable: false));
            AlterColumn("dbo.Personel", "Parola", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personel", "Parola", c => c.String());
            AlterColumn("dbo.Personel", "KullaniciAd", c => c.String());
            AlterColumn("dbo.Personel", "AdSoyad", c => c.String());
        }
    }
}
