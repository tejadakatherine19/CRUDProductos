namespace CrudProductos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        producto = c.String(nullable: false),
                        precio = c.Double(nullable: false),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productoes");
        }
    }
}
