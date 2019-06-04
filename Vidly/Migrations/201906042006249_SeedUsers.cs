namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba19baf0-4728-49aa-8715-ea512d2cc5f9', N'user1@gmail.com', 0, N'AH3ybXtmokocbGGUV5IQtMB3lJQE17XmOU/qEL0N3JvHw0+hLyLEgw1WjTsKmjR3ug==', N'08b42728-c22b-4a75-9ed0-035ccfbe7549', NULL, 0, 0, NULL, 1, 0, N'user1@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'baf685ce-20ef-4198-b2b1-e2bc41e14f03', N'admin1@gmail.com', 0, N'AEWcQ93dlAQtHhr93X3BeCHjUrg2RaHDntEtUa3Hv1b+fkivZrCmvxQheiuHfaZaFw==', N'e2dae042-68af-4d79-babc-dd5f9a33bf05', NULL, 0, 0, NULL, 1, 0, N'admin1@gmail.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'92fb711f-4c44-4c6a-8b85-a1206fb815bd', N'CanManageMovies')
            INSERT INTO[dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES(N'baf685ce-20ef-4198-b2b1-e2bc41e14f03', N'92fb711f-4c44-4c6a-8b85-a1206fb815bd')

            ");


        }
        
        public override void Down()
        {
        }
    }
}
