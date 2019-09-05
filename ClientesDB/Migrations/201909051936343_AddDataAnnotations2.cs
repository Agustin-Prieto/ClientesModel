namespace ClientesDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Ciudad_Id", "dbo.Ciudades");
            DropIndex("dbo.Clientes", new[] { "Ciudad_Id" });
            AlterColumn("dbo.Clientes", "Ciudad_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "Ciudad_Id");
            AddForeignKey("dbo.Clientes", "Ciudad_Id", "dbo.Ciudades", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Ciudad_Id", "dbo.Ciudades");
            DropIndex("dbo.Clientes", new[] { "Ciudad_Id" });
            AlterColumn("dbo.Clientes", "Ciudad_Id", c => c.Int());
            CreateIndex("dbo.Clientes", "Ciudad_Id");
            AddForeignKey("dbo.Clientes", "Ciudad_Id", "dbo.Ciudades", "Id");
        }
    }
}
