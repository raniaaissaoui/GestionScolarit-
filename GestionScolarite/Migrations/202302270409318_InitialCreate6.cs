namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etudiants", "AccoutId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Etudiants", "AccoutId");
        }
    }
}
