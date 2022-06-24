namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8319c6ee-e103-4606-89b0-6b13695e2f66', N'guest@vidly.com', 0, N'AH7IzvLCF+dJYFWT8BL9CrGCEReFr0oBeDI2HAW6NypC2XP+x0sa68GWSeIZnI2cQA==', N'0f3a7a75-1847-4d0b-8fae-28f7fd757d6c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'91ee45a3-cfdf-49b3-bb16-bd3d5e09a9d5', N'admin@vidly.com', 0, N'AOn/zxote4M1aPahnM3sv0FsFAsYyzeVkJxi0202TnDKS0wFKpPlmsRTUpBpAIV1Lg==', N'47d074e8-631d-4f2f-a224-c05da53c1b10', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd27a3c7f-3ff1-4677-9431-b731474bd43f', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'91ee45a3-cfdf-49b3-bb16-bd3d5e09a9d5', N'd27a3c7f-3ff1-4677-9431-b731474bd43f')

");
        }
        
        public override void Down()
        {
        }
    }
}
