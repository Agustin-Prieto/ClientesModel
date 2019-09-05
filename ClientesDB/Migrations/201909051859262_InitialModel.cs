namespace ClientesDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Domicilio = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Habilitado = c.Byte(nullable: false),
                        Ciudad_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ciudades", t => t.Ciudad_Id)
                .Index(t => t.Ciudad_Id);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Detalle = c.String(),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Ciudad_Id", "dbo.Ciudades");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            DropIndex("dbo.Clientes", new[] { "Ciudad_Id" });
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Ciudades");
        }
    }
}
