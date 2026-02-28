namespace IsTakipSistemiMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloIsimDuzeltme : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Birims", newName: "Birim");
            RenameTable(name: "dbo.Personels", newName: "Personel");
            RenameTable(name: "dbo.Isses", newName: "Is");
            RenameTable(name: "dbo.Durums", newName: "Durum");
            RenameTable(name: "dbo.YetkiTurs", newName: "YetkiTur");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.YetkiTur", newName: "YetkiTurs");
            RenameTable(name: "dbo.Durum", newName: "Durums");
            RenameTable(name: "dbo.Is", newName: "Isses");
            RenameTable(name: "dbo.Personel", newName: "Personels");
            RenameTable(name: "dbo.Birim", newName: "Birims");
        }
    }
}
