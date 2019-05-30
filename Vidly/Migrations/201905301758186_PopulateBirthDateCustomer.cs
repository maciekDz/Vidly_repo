namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthDateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='1983-01-04' WHERE CustomerId=1");
        }
        
        public override void Down()
        {
        }
    }
}
