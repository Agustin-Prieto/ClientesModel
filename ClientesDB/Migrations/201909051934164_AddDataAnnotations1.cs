namespace ClientesDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ciudades", "Nombre", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ciudades", "Nombre", c => c.String());
        }
    }
}
