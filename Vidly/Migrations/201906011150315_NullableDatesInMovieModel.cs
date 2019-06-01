namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDatesInMovieModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "RelaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "RelaseDate", c => c.DateTime(nullable: false));
        }
    }
}
