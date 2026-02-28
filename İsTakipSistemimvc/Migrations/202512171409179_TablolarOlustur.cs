namespace IsTakipSistemiMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablolarOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Birims",
                c => new
                    {
                        BirimId = c.Int(nullable: false, identity: true),
                        BirimAd = c.String(),
                    })
                .PrimaryKey(t => t.BirimId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        KullaniciAd = c.String(),
                        Parola = c.String(),
                        Telefon = c.String(),
                        BirimId = c.Int(nullable: false),
                        YetkiTurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Birims", t => t.BirimId, cascadeDelete: true)
                .ForeignKey("dbo.YetkiTurs", t => t.YetkiTurId, cascadeDelete: true)
                .Index(t => t.BirimId)
                .Index(t => t.YetkiTurId);
            
            CreateTable(
                "dbo.Isses",
                c => new
                    {
                        IsId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        PersonelId = c.Int(nullable: false),
                        DurumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IsId)
                .ForeignKey("dbo.Durums", t => t.DurumId, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.PersonelId, cascadeDelete: true)
                .Index(t => t.PersonelId)
                .Index(t => t.DurumId);
            
            CreateTable(
                "dbo.Durums",
                c => new
                    {
                        DurumId = c.Int(nullable: false, identity: true),
                        DurumAd = c.String(),
                    })
                .PrimaryKey(t => t.DurumId);
            
            CreateTable(
                "dbo.YetkiTurs",
                c => new
                    {
                        YetkiTurId = c.Int(nullable: false, identity: true),
                        YetkiAd = c.String(),
                    })
                .PrimaryKey(t => t.YetkiTurId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personels", "YetkiTurId", "dbo.YetkiTurs");
            DropForeignKey("dbo.Isses", "PersonelId", "dbo.Personels");
            DropForeignKey("dbo.Isses", "DurumId", "dbo.Durums");
            DropForeignKey("dbo.Personels", "BirimId", "dbo.Birims");
            DropIndex("dbo.Isses", new[] { "DurumId" });
            DropIndex("dbo.Isses", new[] { "PersonelId" });
            DropIndex("dbo.Personels", new[] { "YetkiTurId" });
            DropIndex("dbo.Personels", new[] { "BirimId" });
            DropTable("dbo.YetkiTurs");
            DropTable("dbo.Durums");
            DropTable("dbo.Isses");
            DropTable("dbo.Personels");
            DropTable("dbo.Birims");
        }
    }
}
