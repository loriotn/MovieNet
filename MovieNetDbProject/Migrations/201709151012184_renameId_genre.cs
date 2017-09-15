namespace MovieNetDbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameId_genre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.film", "genre_id", c => c.Int(nullable: false));
            DropColumn("dbo.film", "id_genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.film", "id_genre", c => c.Int(nullable: false));
            DropColumn("dbo.film", "genre_id");
        }
    }
}
