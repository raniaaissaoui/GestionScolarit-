namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mat2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Enseignants", "matid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enseignants", "matid", c => c.Int(nullable: false));
        }
    }
}
