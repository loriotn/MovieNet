namespace MovieNetDbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdToNotes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.note", "id_film");
            DropColumn("dbo.note", "id_utilisateur");
            RenameColumn(table: "dbo.note", name: "film_id", newName: "id_film");
            RenameColumn(table: "dbo.note", name: "utilisateur_id", newName: "id_utilisateur");
            RenameIndex(table: "dbo.note", name: "IX_film_id", newName: "IX_id_film");
            RenameIndex(table: "dbo.note", name: "IX_utilisateur_id", newName: "IX_id_utilisateur");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.note", name: "IX_id_utilisateur", newName: "IX_utilisateur_id");
            RenameIndex(table: "dbo.note", name: "IX_id_film", newName: "IX_film_id");
            RenameColumn(table: "dbo.note", name: "id_utilisateur", newName: "utilisateur_id");
            RenameColumn(table: "dbo.note", name: "id_film", newName: "film_id");
            AddColumn("dbo.note", "id_utilisateur", c => c.Int(nullable: false));
            AddColumn("dbo.note", "id_film", c => c.Int(nullable: false));
        }
    }
}
