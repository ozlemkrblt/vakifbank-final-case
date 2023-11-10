using Microsoft.EntityFrameworkCore.Migrations;

namespace YourNamespace.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"


                -- Seed data for Role table
SET IDENTITY_INSERT [dbo].[Role] ON;
                INSERT INTO [dbo].[Role] ([Id], [Name] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (1, 'admin',1,'2023-05-05',0,null,1),
                       (2, 'retailer',1,'2023-05-05',0,null,1);
SET IDENTITY_INSERT [dbo].[Role] OFF;



                -- Seed data for User table , password: 12345
SET IDENTITY_INSERT [dbo].[User] ON;
                INSERT INTO [dbo].[User]([Id],[Email] ,[Password] ,[Name] ,[LastName] ,[RoleId] ,[UserName] ,[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (10001 ,'admin1@example.com' ,'827ccb0eea8a706c4c34a16891f84e7b' ,'Admin1' ,'Lucky' ,'1', 'AdMin1' ,'2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1),
                       (20001 ,'retailer1@example.com' ,'827ccb0eea8a706c4c34a16891f84e7b' ,'Retailer1' ,'Successful' ,'2' , 'RetaiLeR1','2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);
SET IDENTITY_INSERT [dbo].[User] OFF;

--Seed data for Address table
SET IDENTITY_INSERT [dbo].[Address] ON;
                INSERT INTO [dbo].[Address] ([Id], [UserId], [AddressLine1], [AddressLine2], [City] , [District] , [PostalCode],[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
                VALUES (1,20001, '123 Main St, Good Boulevard', 'Number 18,Flat Number 3','Berlin', 'Center', 10117 ,1,'2023-05-05',0,null,1);
SET IDENTITY_INSERT [dbo].[Address] OFF;

                -- Seed data for Admin table
--SET IDENTITY_INSERT [dbo].[Admin] ON;
               -- INSERT INTO [dbo].[Admin] ([Id])
--,[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
               -- VALUES (10001);
--,'2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);
--SET IDENTITY_INSERT [dbo].[Admin] OFF;



                -- Seed data for Retailer table
--SET IDENTITY_INSERT [dbo].[Retailer] ON;
                --INSERT INTO [dbo].[Retailer] ([Id])
--,[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
               -- VALUES (20001);
---,'2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);
--SET IDENTITY_INSERT [dbo].[Retailer] OFF;
            ");

            /*  migrationBuilder.Sql(@"
       --Seed data for Role table
SET IDENTITY_INSERT[dbo].[Role] ON;
       INSERT INTO[dbo].[Role] ([Id], [Name], [InsertUserId], [InsertDate], [UpdateUserId], [UpdateDate], [IsActive])
           VALUES(1, 'admin', 1, '2023-05-05', 0, null, 1),
                  (2, 'retailer', 1, '2023-05-05', 0, null, 1);
       SET IDENTITY_INSERT[dbo].[Role] OFF;



       --Seed data for User table
SET IDENTITY_INSERT[dbo].[User] ON;
       INSERT INTO[dbo].[User] ( [Email], [Password], [Name], [LastName], [RoleId], [UserName], [LastActivityDate], [PasswordRetryCount], [InsertUserId], [InsertDate], [UpdateUserId], [UpdateDate], [IsActive])
           VALUES( 'admin1@example.com', '12345', 'Admin1', 'Lucky', '1', 'AdMin1', '2023-07-07', 0, 0, '2023-07-07', 0, '2023-07-07', 1),
                  ( 'retailer1@example.com', '12345', 'Retailer1', 'Successful', '2', 'RetaiLeR1', '2023-07-07', 0, 0, '2023-07-07', 0, '2023-07-07', 1);
       SET IDENTITY_INSERT[dbo].[User] OFF;

       --Seed data for Address table
       SET IDENTITY_INSERT[dbo].[Address] ON;
       INSERT INTO[dbo].[Address] ([Id], [UserId], [AddressLine1], [AddressLine2], [City], [District], [PostalCode], [InsertUserId], [InsertDate], [UpdateUserId], [UpdateDate], [IsActive])
           VALUES(1, 20001, '123 Main St, Good Boulevard', 'Number 18,Flat Number 3', 'Berlin', 'Center', 10117, 1, '2023-05-05', 0, null, 1);
       SET IDENTITY_INSERT[dbo].[Address] OFF;

       --Seed data for Admin table
--SET IDENTITY_INSERT[dbo].[Admin] ON;
       --INSERT INTO[dbo].[Admin]([Id])
--,[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
       --   VALUES(10001);
       --,'2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);
       --SET IDENTITY_INSERT[dbo].[Admin] OFF;



       --Seed data for Retailer table
--SET IDENTITY_INSERT[dbo].[Retailer] ON;
       --INSERT INTO[dbo].[Retailer]([Id])
--,[LastActivityDate] ,[PasswordRetryCount] ,[InsertUserId] ,[InsertDate] ,[UpdateUserId] ,[UpdateDate] ,[IsActive])
          --VALUES(20001);
       ---,'2023-07-07' ,0 ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,1);
       --SET IDENTITY_INSERT[dbo].[Retailer] OFF;
       ");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
