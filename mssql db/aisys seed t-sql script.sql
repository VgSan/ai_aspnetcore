USE [Aisys]
GO

---- Seeding roles
--INSERT INTO [dbo].[Role] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[RoleCd] ,[RoleName], [Level])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,'SysAdmin' ,'System Admin', 1)
--INSERT INTO [dbo].[Role] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[RoleCd] ,[RoleName], [Level])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,'OutDorEng' ,'Outdoor Engineers', 2)
--INSERT INTO [dbo].[Role] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[RoleCd] ,[RoleName], [Level])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,'Crdnt_ChifPlner' ,'Coordinatore - Chief planer', 3)
--INSERT INTO [dbo].[Role] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[RoleCd] ,[RoleName], [Level])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,'WrkshpEng' ,'Workshop Engineers', 4)
--GO

---- Seeding users
--INSERT INTO [dbo].[User] ([AddedDate] ,[Email] ,[IsActive] ,[ModifiedDate] ,[Password])
--     VALUES ('3/27/2018' ,'admin@aisys.com' ,1 ,'3/27/2018' ,'admin123')
--INSERT INTO [dbo].[User] ([AddedDate] ,[Email] ,[IsActive] ,[ModifiedDate] ,[Password])
--     VALUES ('3/27/2018' ,'engineers@aisys.com' ,1 ,'3/27/2018' ,'engineers123')
--GO

--select * from [dbo].[User]
--select * from [dbo].[Role]
--GO

---- Seeding user roles
--INSERT INTO [dbo].[UserRole] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[UserId] ,[RoleId])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,1 ,1)
--INSERT INTO [dbo].[UserRole] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[UserId] ,[RoleId])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,1 ,2)
--INSERT INTO [dbo].[UserRole] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[UserId] ,[RoleId])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,1 ,3)
--INSERT INTO [dbo].[UserRole] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[UserId] ,[RoleId])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,1 ,4)
--INSERT INTO [dbo].[UserRole] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[UserId] ,[RoleId])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,2 ,2)
--INSERT INTO [dbo].[UserRole] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[UserId] ,[RoleId])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,2 ,3)
--INSERT INTO [dbo].[UserRole] ([AddedDate] ,[IsActive] ,[ModifiedDate] ,[UserId] ,[RoleId])
--     VALUES ('3/27/2018' ,1 ,'3/27/2018' ,2 ,4)
--GO

--select * from [dbo].[UserRole]
--GO





