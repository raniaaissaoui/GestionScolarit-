namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mat5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Affectations", "selectedOptions", c => c.Boolean(nullable: false));
            AddColumn("dbo.Matieres", "Affectation_Id", c => c.Int());
            CreateIndex("dbo.Matieres", "Affectation_Id");
            AddForeignKey("dbo.Matieres", "Affectation_Id", "dbo.Affectations", "Id");
            DropColumn("dbo.Matieres", "ischecked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matieres", "ischecked", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Matieres", "Affectation_Id", "dbo.Affectations");
            DropIndex("dbo.Matieres", new[] { "Affectation_Id" });
            DropColumn("dbo.Matieres", "Affectation_Id");
            DropColumn("dbo.Affectations", "selectedOptions");
        }
    }
}
