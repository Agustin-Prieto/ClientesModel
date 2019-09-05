namespace ClientesDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clientes", "Apellido", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clientes", "Domicilio", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clientes", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clientes", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Facturas", "Detalle", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Facturas", "Cliente_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "Cliente_Id");
            AddForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            AlterColumn("dbo.Facturas", "Cliente_Id", c => c.Int());
            AlterColumn("dbo.Facturas", "Detalle", c => c.String());
            AlterColumn("dbo.Clientes", "Password", c => c.String());
            AlterColumn("dbo.Clientes", "Email", c => c.String());
            AlterColumn("dbo.Clientes", "Domicilio", c => c.String());
            AlterColumn("dbo.Clientes", "Apellido", c => c.String());
            AlterColumn("dbo.Clientes", "Nombre", c => c.String());
            CreateIndex("dbo.Facturas", "Cliente_Id");
            AddForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes", "Id");
        }
    }
}
