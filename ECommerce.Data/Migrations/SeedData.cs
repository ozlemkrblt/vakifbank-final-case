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
                VALUES (1,2001, '123 Main St, Good Boulevard', 'Number 18,Flat Number 3','Berlin', 'Center', 10117,1,'2023-05-05',0,null,1)


                -- Seed data for User table
                INSERT INTO [dbo].[User] ([Id], [Name], [LastName], [Email], [Password], [UserName], [RoleId],[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (1001, 'Admin1',' Lucky',  'admin1@example.com', 'admin1', 'admin', 1,1,'2023-05-05',0,null,1),
                       (2001, 'Retailer1', 'Successfull','retailer1@example.com', 'retailer1', 'retailer', 2,1,'2023-05-05',0,null,1);

                -- Seed data for Admin table
                INSERT INTO [dbo].[Admin] ([Id],[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (1001,1,'2023-05-05',0,null,1);

                -- Seed data for Retailer table
                INSERT INTO [dbo].[Retailer] ([Id],[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (2001,2,'2023-05-05',0,null,1);

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
