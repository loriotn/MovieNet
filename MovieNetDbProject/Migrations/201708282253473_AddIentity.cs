namespace MovieNetDbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.commentaire", "id_film", "dbo.film");
            DropForeignKey("dbo.commentaire", "id_utilisateur", "dbo.utilisateur");
            DropForeignKey("dbo.film", "id_genre", "dbo.genre");
            DropForeignKey("dbo.note", "id_film", "dbo.film");
            DropForeignKey("dbo.note", "id_utilisateur", "dbo.utilisateur");
            DropIndex("dbo.commentaire", new[] { "id_film" });
            DropIndex("dbo.commentaire", new[] { "id_utilisateur" });
            DropIndex("dbo.film", new[] { "id_genre" });
            DropIndex("dbo.note", new[] { "id_film" });
            DropIndex("dbo.note", new[] { "id_utilisateur" });
            AddColumn("dbo.commentaire", "film_id", c => c.Int(nullable: false));
            AddColumn("dbo.commentaire", "utilisateur_id", c => c.Int(nullable: false));
            AddColumn("dbo.film", "genre_id", c => c.Int(nullable: false));
            AddColumn("dbo.note", "utilisateur_id", c => c.Int(nullable: false));
            AddColumn("dbo.note", "film_id", c => c.Int(nullable: false));
            CreateIndex("dbo.commentaire", "film_id");
            CreateIndex("dbo.commentaire", "utilisateur_id");
            CreateIndex("dbo.film", "genre_id");
            CreateIndex("dbo.note", "utilisateur_id");
            CreateIndex("dbo.note", "film_id");
            AddForeignKey("dbo.commentaire", "film_id", "dbo.film", "id_film");
            AddForeignKey("dbo.commentaire", "utilisateur_id", "dbo.utilisateur", "id_utilisateur");
            AddForeignKey("dbo.film", "genre_id", "dbo.genre", "id_genre");
            AddForeignKey("dbo.note", "film_id", "dbo.film", "id_film");
            AddForeignKey("dbo.note", "utilisateur_id", "dbo.utilisateur", "id_utilisateur");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.note", "utilisateur_id", "dbo.utilisateur");
            DropForeignKey("dbo.note", "film_id", "dbo.film");
            DropForeignKey("dbo.film", "genre_id", "dbo.genre");
            DropForeignKey("dbo.commentaire", "utilisateur_id", "dbo.utilisateur");
            DropForeignKey("dbo.commentaire", "film_id", "dbo.film");
            DropIndex("dbo.note", new[] { "film_id" });
            DropIndex("dbo.note", new[] { "utilisateur_id" });
            DropIndex("dbo.film", new[] { "genre_id" });
            DropIndex("dbo.commentaire", new[] { "utilisateur_id" });
            DropIndex("dbo.commentaire", new[] { "film_id" });
            DropColumn("dbo.note", "film_id");
            DropColumn("dbo.note", "utilisateur_id");
            DropColumn("dbo.film", "genre_id");
            DropColumn("dbo.commentaire", "utilisateur_id");
            DropColumn("dbo.commentaire", "film_id");
            CreateIndex("dbo.note", "id_utilisateur");
            CreateIndex("dbo.note", "id_film");
            CreateIndex("dbo.film", "id_genre");
            CreateIndex("dbo.commentaire", "id_utilisateur");
            CreateIndex("dbo.commentaire", "id_film");
            AddForeignKey("dbo.note", "id_utilisateur", "dbo.utilisateur", "id_utilisateur");
            AddForeignKey("dbo.note", "id_film", "dbo.film", "id_film");
            AddForeignKey("dbo.film", "id_genre", "dbo.genre", "id_genre");
            AddForeignKey("dbo.commentaire", "id_utilisateur", "dbo.utilisateur", "id_utilisateur");
            AddForeignKey("dbo.commentaire", "id_film", "dbo.film", "id_film");
        }
    }
}
