namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
	        Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3fc9a8fc-130e-479c-aacd-5dca78c2bbde', N'admin@jelsert.com', 0, N'AF7b8PO60p6Qn8leZko1WIU8w8x7cQN0J1NtmkD+LfT5QQTSqML4F1jsa0SX0xNdQg==', N'0f224f59-8a03-4b39-a5b0-71c61bb035c8', NULL, 0, 0, NULL, 1, 0, N'admin@jelsert.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c1eda558-c897-46f6-b8e2-bd20799a85a2', N'guest@jelsert.com', 0, N'AGGEbqFB+GWM9CuskdDW3ylHUwk9a2y2npbsDkLF2ycgUzyy3N/wUNh83Kkg4HLw9Q==', N'0be78b4c-3da1-4d86-89bb-e0c45534544b', NULL, 0, 0, NULL, 1, 0, N'guest@jelsert.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ceab4c22-7a37-483b-90b9-0835ac94e3b3', N'CanManageAccounts')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ed62b020-0f43-476e-83ea-88a9a8750af9', N'CanManageSampleLocations')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3fc9a8fc-130e-479c-aacd-5dca78c2bbde', N'ceab4c22-7a37-483b-90b9-0835ac94e3b3')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3fc9a8fc-130e-479c-aacd-5dca78c2bbde', N'ed62b020-0f43-476e-83ea-88a9a8750af9')


");
        }
        
        public override void Down()
        {
        }
    }
}
