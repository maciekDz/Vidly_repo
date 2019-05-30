namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembeshipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Pay as You Go' WHERE MembershipTypeId=1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Monthly' WHERE MembershipTypeId=2");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Quarterly' WHERE MembershipTypeId=3");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Yearly' WHERE MembershipTypeId=4");
        }
        
        public override void Down()
        {
        }
    }
}
