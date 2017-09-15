namespace MovieNetDbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteGenreObjectFromMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.film", "genre_id", "dbo.genre");
            DropIndex("dbo.film", new[] { "genre_id" });
            DropColumn("dbo.film", "genre_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.film", "genre_id", c => c.Int());
            CreateIndex("dbo.film", "genre_id");
            AddForeignKey("dbo.film", "genre_id", "dbo.genre", "id_genre");
        }
    }
}
