namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matieres", "Assignation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matieres", "Assignation");
        }
    }
}
