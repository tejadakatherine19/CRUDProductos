namespace CrudProductos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambio_nombre : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Productoes");
            AlterColumn("dbo.Productoes", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Productoes", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Productoes");
            AlterColumn("dbo.Productoes", "id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Productoes", "id");
        }
    }
}
