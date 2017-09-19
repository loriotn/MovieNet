namespace MovieNetDbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDatesToMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.film", "genre_id", "dbo.genre");
            DropForeignKey("dbo.commentaire", "film_id", "dbo.film");
            DropForeignKey("dbo.note", "film_id", "dbo.film");
            DropForeignKey("dbo.note", "utilisateur_id", "dbo.utilisateur");
            DropIndex("dbo.film", new[] { "genre_id" });
            DropColumn("dbo.commentaire", "id_film");
            DropColumn("dbo.commentaire", "id_utilisateur");
            DropColumn("dbo.note", "id_film");
            DropColumn("dbo.note", "id_utilisateur");
            RenameColumn(table: "dbo.commentaire", name: "film_id", newName: "id_film");
            RenameColumn(table: "dbo.commentaire", name: "utilisateur_id", newName: "id_utilisateur");
            RenameColumn(table: "dbo.note", name: "film_id", newName: "id_film");
            RenameColumn(table: "dbo.note", name: "utilisateur_id", newName: "id_utilisateur");
            RenameIndex(table: "dbo.commentaire", name: "IX_film_id", newName: "IX_id_film");
            RenameIndex(table: "dbo.commentaire", name: "IX_utilisateur_id", newName: "IX_id_utilisateur");
            RenameIndex(table: "dbo.note", name: "IX_film_id", newName: "IX_id_film");
            RenameIndex(table: "dbo.note", name: "IX_utilisateur_id", newName: "IX_id_utilisateur");
            DropPrimaryKey("dbo.commentaire");
            DropPrimaryKey("dbo.note");
            AddColumn("dbo.commentaire", "id_commentaire", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.film", "register_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.film", "release_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.note", "id_note", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.commentaire", "id_commentaire");
            AddPrimaryKey("dbo.note", "id_note");
            AddForeignKey("dbo.commentaire", "id_film", "dbo.film", "id_film", cascadeDelete: true);
            AddForeignKey("dbo.note", "id_film", "dbo.film", "id_film", cascadeDelete: true);
            AddForeignKey("dbo.note", "id_utilisateur", "dbo.utilisateur", "id_utilisateur", cascadeDelete: true);
            DropColumn("dbo.film", "id_genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.film", "id_genre", c => c.Int(nullable: false));
            DropForeignKey("dbo.note", "id_utilisateur", "dbo.utilisateur");
            DropForeignKey("dbo.note", "id_film", "dbo.film");
            DropForeignKey("dbo.commentaire", "id_film", "dbo.film");
            DropPrimaryKey("dbo.note");
            DropPrimaryKey("dbo.commentaire");
            DropColumn("dbo.note", "id_note");
            DropColumn("dbo.film", "release_date");
            DropColumn("dbo.film", "register_date");
            DropColumn("dbo.commentaire", "id_commentaire");
            AddPrimaryKey("dbo.note", new[] { "id_film", "id_utilisateur" });
            AddPrimaryKey("dbo.commentaire", new[] { "id_film", "id_utilisateur" });
            RenameIndex(table: "dbo.note", name: "IX_id_utilisateur", newName: "IX_utilisateur_id");
            RenameIndex(table: "dbo.note", name: "IX_id_film", newName: "IX_film_id");
            RenameIndex(table: "dbo.commentaire", name: "IX_id_utilisateur", newName: "IX_utilisateur_id");
            RenameIndex(table: "dbo.commentaire", name: "IX_id_film", newName: "IX_film_id");
            RenameColumn(table: "dbo.note", name: "id_utilisateur", newName: "utilisateur_id");
            RenameColumn(table: "dbo.note", name: "id_film", newName: "film_id");
            RenameColumn(table: "dbo.commentaire", name: "id_utilisateur", newName: "utilisateur_id");
            RenameColumn(table: "dbo.commentaire", name: "id_film", newName: "film_id");
            AddColumn("dbo.note", "id_utilisateur", c => c.Int(nullable: false));
            AddColumn("dbo.note", "id_film", c => c.Int(nullable: false));
            AddColumn("dbo.commentaire", "id_utilisateur", c => c.Int(nullable: false));
            AddColumn("dbo.commentaire", "id_film", c => c.Int(nullable: false));
            CreateIndex("dbo.film", "genre_id");
            AddForeignKey("dbo.note", "utilisateur_id", "dbo.utilisateur", "id_utilisateur");
            AddForeignKey("dbo.note", "film_id", "dbo.film", "id_film");
            AddForeignKey("dbo.commentaire", "film_id", "dbo.film", "id_film");
            AddForeignKey("dbo.film", "genre_id", "dbo.genre", "id_genre");
        }
    }
}
