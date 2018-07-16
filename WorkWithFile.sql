USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='WorkWithFiles') 
BEGIN 
DROP DATABASE WorkWithFiles
END 
GO 

CREATE DATABASE WorkWithFiles
GO 

USE WorkWithFiles
GO

CREATE TABLE [User] (
	id_user int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_USER] PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	[Password] varchar(100) NOT NULL,
	[Role] int NOT NULL
)
GO

CREATE TABLE [File] (
	id_file int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_FILE] PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	Mark int NOT NULL,
	[Text] varchar(300) NOT NULL
)
GO

CREATE TABLE UserFile (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_USERFILE] PRIMARY KEY,
	id_user int NOT NULL,
	id_file int NOT NULL
)
GO

CREATE TABLE Comment (
	id_comment int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_COMMENT] PRIMARY KEY,
	Comment varchar(500)
)

CREATE TABLE FileComment (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_FILECOMMENT] PRIMARY KEY,
	id_file int NOT NULL,
	id_comment int NOT NULL
)
GO

ALTER TABLE [UserFile] ADD CONSTRAINT [FK_UserFile_User]
FOREIGN KEY ([id_user]) references [User]([id_user])
on delete cascade
on update cascade
GO

ALTER TABLE [UserFile] ADD CONSTRAINT [FK_UserFile_File]
FOREIGN KEY ([id_file]) references [File]([id_file])
on delete cascade
on update cascade
GO

ALTER TABLE [FileComment] ADD CONSTRAINT [FK_FileComment_File]
FOREIGN KEY ([id_file]) references [File]([id_file])
on delete cascade
on update cascade
GO

ALTER TABLE [FileComment] ADD CONSTRAINT [FK_FileComment_Comment]
FOREIGN KEY ([id_comment]) references [Comment]([id_comment])
on delete cascade
on update cascade
GO

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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CreateFile
	@ID int,
	@NAME varchar(255),
	@MARK int = 0,
	@TEXT varchar(300)
AS
BEGIN
	INSERT INTO [dbo].[File]
           ([Name]
           ,[Mark]
           ,[Text])
     VALUES
           (@NAME
           ,@MARK
           ,@TEXT)

	INSERT INTO dbo.UserFile
	(id_user,
	id_file)
	VALUES
	(@ID
	,(SELECT TOP(1) id_file FROM [File] ORDER BY id_file DESC))

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CreateComment
	@ID int,
	@COMMENT varchar(500)
AS
BEGIN
	INSERT INTO [dbo].[Comment]
           (Comment)
     VALUES
           (@COMMENT)

	INSERT INTO dbo.FileComment
	(id_file
	,id_comment)
	VALUES
	(@ID
	,(SELECT TOP(1) id_comment FROM [Comment] ORDER BY id_comment DESC))

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ReadUser	
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Password]
      ,[Role]
  FROM [WorkWithFiles].[dbo].[User]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ReadFile	
AS
BEGIN
	SELECT [id_file]
      ,[Name]
      ,[Mark]
      ,[Text]
  FROM [WorkWithFiles].[dbo].[File]
END
GO

CREATE PROCEDURE ReadCommentByFile
	@ID int	
AS
BEGIN
	SELECT C.id_comment as id_comment, 
	C.Comment as Comment
	FROM FileComment as FC
	JOIN Comment as C ON FC.id_comment=C.id_comment
	WHERE FC.id_file = @ID
END
GO

CREATE PROCEDURE UpdateUser
	@ID int	,
	@NAME varchar(255),
	@PASSWORD varchar(300)
AS
BEGIN
	UPDATE [dbo].[User]
   SET [Name] = @NAME
      ,[Password] = @PASSWORD
 WHERE id_user = @ID
END
GO

CREATE PROCEDURE UpdateUserByAdmin
	@ID int	,
	@ROLE int
AS
BEGIN
	UPDATE [dbo].[User]
   SET [Role] = @ROLE
 WHERE id_user = @ID
END
GO

CREATE PROCEDURE DeleteUser
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[User]
      WHERE id_user = @ID
END
GO

CREATE PROCEDURE DeleteFile
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[File]
      WHERE id_file = @ID
END
GO

CREATE PROCEDURE UpdateFileText
	@ID int,
	@TEXT varchar(300)
AS
BEGIN
	UPDATE [dbo].[File]
   SET [Text] = @TEXT
 WHERE id_file = @ID
END
GO

CREATE PROCEDURE UpdateFileMark
	@ID int,
	@MARK int
AS
BEGIN
	UPDATE [dbo].[File]
   SET [Mark] = @MARK
 WHERE id_file = @ID
END
GO

INSERT INTO [dbo].[User]
           ([Name]
           ,[Password]
           ,[Role])
     VALUES
           ('admin'
           ,'admin'
           ,1)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ReadFileByUser 
	@ID int
AS
BEGIN
	SELECT 
	F.id_file as id_file,
	F.Mark as Mark,
	F.[Name] as [Name],
	F.[Text] as [Text]
	FROM [File] as F
	JOIN UserFile as US ON US.id_file=F.id_file
	WHERE US.id_user = @ID
END
GO
