namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableNumInStockInMoviesModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
    }
}
