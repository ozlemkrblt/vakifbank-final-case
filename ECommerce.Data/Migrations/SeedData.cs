using Microsoft.EntityFrameworkCore.Migrations;

namespace YourNamespace.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                -- Seed data for User table
                INSERT INTO [dbo].[Role] ([Id], [Name],[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (1, 'admin',1,'2023-05-05',0,null,1),
                       (2, 'retailer',1,'2023-05-05',0,null,1);

                INSERT INTO [dbo].[Address] ([Id], [UserId], [AddressLine1], [AddressLine2], [City] , [District] , [PostalCode],[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (1,2001, '123 Main St, Good Boulevard', 'Number 18,Flat Number 3','Berlin', 'Center', 10117,1,'2023-05-05',0,null,1);


                -- Seed data for User table
                INSERT INTO [dbo].[User]([Id],[Email] ,[Password] ,[Name] ,[LastName] ,[RoleId] ,[UserName],[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (10001 ,'admin1@example.com' ,'12345' ,'Admin1' ,'Lucky' ,'1', 'AdMin1','2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1),
                VALUES (20001 ,'retailer1@example.com' ,'12345' ,'Retailer1' ,'Successful' ,'2' 'RetaiLeR1','2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);
                -- Seed data for Admin table
                INSERT INTO [dbo].[Admin] ([Id],[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (10001,'2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);

                -- Seed data for Retailer table
                INSERT INTO [dbo].[Retailer] ([Id],[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (20001,'2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
