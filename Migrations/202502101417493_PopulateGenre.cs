namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Title) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Title) VALUES ('Action')");
            Sql("INSERT INTO Genres (Title) VALUES ('Family')");
            Sql("INSERT INTO Genres (Title) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
