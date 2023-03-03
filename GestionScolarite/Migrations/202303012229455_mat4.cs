namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mat4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matieres", "ischecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matieres", "ischecked");
        }
    }
}
