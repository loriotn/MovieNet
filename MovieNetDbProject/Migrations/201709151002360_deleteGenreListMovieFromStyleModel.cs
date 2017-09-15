namespace MovieNetDbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteGenreListMovieFromStyleModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.commentaire",
                c => new
                    {
                        id_film = c.Int(nullable: false),
                        id_utilisateur = c.Int(nullable: false),
                        id_commentaire = c.Int(nullable: false, identity: true),
                        commentaire = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id_commentaire)
                .ForeignKey("dbo.film", t => t.id_film)
                .ForeignKey("dbo.utilisateur", t => t.id_utilisateur)
                .Index(t => t.id_film)
                .Index(t => t.id_utilisateur);
            
            CreateTable(
                "dbo.film",
                c => new
                    {
                        id_film = c.Int(nullable: false, identity: true),
                        titre_film = c.String(nullable: false, maxLength: 255, unicode: false),
                        resume_film = c.String(unicode: false, storeType: "text"),
                        id_genre = c.Int(nullable: false),
                        genre_id = c.Int(),
                    })
                .PrimaryKey(t => t.id_film)
                .ForeignKey("dbo.genre", t => t.genre_id)
                .Index(t => t.genre_id);
            
            CreateTable(
                "dbo.genre",
                c => new
                    {
                        id_genre = c.Int(nullable: false, identity: true),
                        label_genre = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id_genre);
            
            CreateTable(
                "dbo.note",
                c => new
                    {
                        id_film = c.Int(nullable: false),
                        id_utilisateur = c.Int(nullable: false),
                        id_note = c.Int(nullable: false, identity: true),
                        note = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_note)
                .ForeignKey("dbo.utilisateur", t => t.id_utilisateur)
                .ForeignKey("dbo.film", t => t.id_film)
                .Index(t => t.id_film)
                .Index(t => t.id_utilisateur);
            
            CreateTable(
                "dbo.utilisateur",
                c => new
                    {
                        id_utilisateur = c.Int(nullable: false, identity: true),
                        nom_utilisateur = c.String(nullable: false, maxLength: 255, unicode: false),
                        prenom_utilisateur = c.String(nullable: false, maxLength: 255, unicode: false),
                        mdp_utilisateur = c.String(nullable: false, maxLength: 255, unicode: false),
                        connecte = c.Boolean(nullable: false),
                        inscrit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_utilisateur);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.note", "id_film", "dbo.film");
            DropForeignKey("dbo.note", "id_utilisateur", "dbo.utilisateur");
            DropForeignKey("dbo.commentaire", "id_utilisateur", "dbo.utilisateur");
            DropForeignKey("dbo.film", "genre_id", "dbo.genre");
            DropForeignKey("dbo.commentaire", "id_film", "dbo.film");
            DropIndex("dbo.note", new[] { "id_utilisateur" });
            DropIndex("dbo.note", new[] { "id_film" });
            DropIndex("dbo.film", new[] { "genre_id" });
            DropIndex("dbo.commentaire", new[] { "id_utilisateur" });
            DropIndex("dbo.commentaire", new[] { "id_film" });
            DropTable("dbo.utilisateur");
            DropTable("dbo.note");
            DropTable("dbo.genre");
            DropTable("dbo.film");
            DropTable("dbo.commentaire");
        }
    }
}
