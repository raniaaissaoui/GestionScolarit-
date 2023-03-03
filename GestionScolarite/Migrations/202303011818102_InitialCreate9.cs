namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enseignants",
                c => new
                    {
                        EnseignantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        matid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnseignantId);
            
            CreateTable(
                "dbo.Matieres",
                c => new
                    {
                        MatiereId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        coeff = c.String(),
                    })
                .PrimaryKey(t => t.MatiereId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Matieres");
            DropTable("dbo.Enseignants");
        }
    }
}
