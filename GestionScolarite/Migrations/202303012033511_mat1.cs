namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mat1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enseignants", "matid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enseignants", "matid");
        }
    }
}
