USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='Blogs') 
BEGIN 
DROP DATABASE Blogs
END 
GO 

CREATE DATABASE Blogs
GO 

USE Blogs
GO

CREATE TABLE [User] (
	id_user int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_USER] PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	[Password] varchar(100) NOT NULL,
	[Role] int NOT NULL
)
GO

CREATE TABLE Blog (
	id_blog int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_SKILL] PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	Rating int NOT NULL,
	[Text] varchar(300) NOT NULL
)
GO

CREATE TABLE UserBlog (
	id_user int NOT NULL,
	id_blog int NOT NULL
)
GO

ALTER TABLE [UserBlog] ADD CONSTRAINT [FK_UserBlog_User]
FOREIGN KEY ([id_user]) references [User]([id_user])
on delete cascade
on update cascade
GO

ALTER TABLE [UserBlog] ADD CONSTRAINT [FK_UserBlog_Skill]
FOREIGN KEY ([id_blog]) references [Blog]([id_blog])
on delete cascade
on update cascade
GO

CREATE CLUSTERED INDEX CL_INDEX_UserSkill_COMPOSITE
ON dbo.UserBlog (id_user, id_blog)
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CreateUserByAdmin
	@NAME varchar(255),
	@PASSWORD varchar(300),
	@ROLE int
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Name]
           ,[Password]
           ,[Role])
     VALUES
           (@NAME
           ,@PASSWORD
           ,@ROLE)

	SELECT SCOPE_IDENTITY()
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CreateBlog
	@NAME varchar(255),
	@RATING int = 0,
	@TEXT varchar(300)
AS
BEGIN
	INSERT INTO [dbo].[Blog]
           ([Name]
           ,[Rating]
           ,[Text])
     VALUES
           (@NAME
           ,@RATING
           ,@TEXT)

	SELECT SCOPE_IDENTITY()
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ReadUsers
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Role]
  FROM [Blogs].[dbo].[User]
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ReadBlogs
AS
BEGIN
	SELECT [id_blog]
      ,[Name]
      ,[Rating]
      ,[Text]
  FROM [Blogs].[dbo].[Blog]
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ReadUsersByAdmin 
AS
BEGIN
	SELECT [id_user]
      ,[Name]
	  ,[Password]
      ,[Role]
  FROM [Blogs].[dbo].[User]
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateBlogByAdmin
	@ID int,
	@NAME varchar(255),
	@TEXT varchar(500),
	@RATING int
AS
BEGIN
	UPDATE [dbo].[Blog]
   SET [Name] = @NAME
      ,[Rating] = @RATING
      ,[Text] = @TEXT
 WHERE id_blog = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateUserByAdmin
	@ID int,
	@NAME varchar(255),
	@PASSWORD varchar(255),
	@ROLE int
AS
BEGIN
	UPDATE [dbo].[User]
   SET [Name] = @NAME
      ,[Password] = @PASSWORD
	  ,[Role] = @ROLE
 WHERE id_user = @ID
END
GO

CREATE PROCEDURE UpdateBlog
	@ID int,
	@RATING int
AS
BEGIN
	UPDATE [dbo].[Blog]
   SET [Rating] = @RATING
 WHERE id_blog = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateUser
	@ID int,
	@NAME varchar(255),
	@PASSWORD varchar(255)
AS
BEGIN
	UPDATE [dbo].[User]
   SET [Name] = @NAME
      ,[Password] = @PASSWORD
 WHERE id_user = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DeleteUser 
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[User]
      WHERE id_user = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DeleteBlog
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[Blog]
      WHERE id_blog = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetUserById
	@ID int
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Password]
      ,[Role]
  FROM [dbo].[User]
  WHERE id_user = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetBlogById
	@ID int
AS
BEGIN
	SELECT [id_blog]
      ,[Name]
      ,[Rating]
      ,[Text]
  FROM [Blogs].[dbo].[Blog]
  WHERE id_blog = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CreateUser 
	@NAME varchar(255),
	@PASSWORD varchar(300),
	@ROLE int = 3
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Name]
           ,[Password]
           ,[Role])
     VALUES
           (@NAME
           ,@PASSWORD
           ,@ROLE)

	SELECT SCOPE_IDENTITY()
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetBlogsByUser
	@ID int
AS
BEGIN
	SELECT B.id_blog as id,
	B.[Name] as [name],
	B.Rating as rating,
	B.[Text] as [text] 
	FROM UserBlog as UB
	JOIN Blog as B ON B.id_blog = UB.id_blog
	WHERE UB.id_user = @ID
END
GO