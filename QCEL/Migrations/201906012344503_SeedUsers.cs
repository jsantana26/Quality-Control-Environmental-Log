namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
	        Sql(
				@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3aff928c-fe4e-4e8f-a76e-66029ef0b3d0', N'jsantana@jelsert.com', 0, N'AF7QA2vsAtCaH/RnZ4sTSGak+vfc17lYxYjSwSW6BACZWytrsHRcYTp2tqtxQxJKxA==', N'e0847272-4c21-4ed9-bffb-c76dd26546aa', NULL, 0, 0, NULL, 1, 0, N'jsantana@jelsert.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc83a5de-bb27-4647-aace-8247862fc2e1', N'guest@jelsert.com', 0, N'AJYTHS/+ol6G9FXMA+j2496hKlCxsMFS8e3Ve8kWtzB4wDttwVMdRTV2+Up+wXsbKA==', N'33cd7d10-490f-4d71-9d38-8afecb059bfe', NULL, 0, 0, NULL, 1, 0, N'guest@jelsert.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f4a6a82a-4d34-451b-9712-3b4a98640b28', N'CanManageSampleLocations')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3aff928c-fe4e-4e8f-a76e-66029ef0b3d0', N'f4a6a82a-4d34-451b-9712-3b4a98640b28')

");
        }
        
        public override void Down()
        {
        }
    }
}
