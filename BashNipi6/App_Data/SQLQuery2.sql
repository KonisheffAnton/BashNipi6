USE [BashNipi2]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[objectB]') AND type in (N'U'))
DROP TABLE [dbo].[objectB]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project]') AND type in (N'U'))
DROP TABLE [dbo].[Project]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 25.08.2021 15:22:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[Id] [int] NOT NULL,
	[ProjectName] [nvarchar](30) NOT NULL,
	[CreateData] [datetime] NOT NULL,
	[ChangeData] [datetime] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[object]    Script Date: 25.08.2021 11:09:46 ******/


/****** Object:  Table [dbo].[object]    Script Date: 25.08.2021 11:09:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[objectB](
	[Id] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[objectName] [nvarchar](30) NOT NULL,
	[CreateData] [datetime] NOT NULL,
	[ChangeData] [datetime] NOT NULL,
 CONSTRAINT [PK_objectB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[objectB]  WITH CHECK ADD  CONSTRAINT [FK_objectB_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[objectB] CHECK CONSTRAINT [FK_objectB_Project]

GO

INSERT INTO [dbo].[Project]
           ([Id]
           ,[ProjectName]
           ,[CreateData]
           ,[ChangeData])
     VALUES
           ('1' ,'Нефтепровод',GETDATE(),GETDATE()),
		   ('2' ,'Автодорога',GETDATE(),GETDATE()),
		   ('3' ,'Кустовая площадка ',GETDATE(),GETDATE())
		  
GO

INSERT INTO [dbo].[objectB]
           ([Id]
           ,[ProjectId]
           ,[objectName]
           ,[CreateData]
           ,[ChangeData])
     VALUES
           ('11','1' ,'Прожекторная площадка',GETDATE(),GETDATE()),
		   ('12','2' ,'Дренажная ёмкость',GETDATE(),GETDATE()),
		   ('13','3' ,'Нужная штука',GETDATE(),GETDATE()),
		   ('22','2' ,'Штуковкина',GETDATE(),GETDATE()),
		   ('23','2' ,'Насос',GETDATE(),GETDATE()),
		   ('32','3' ,'Ну очень нужная штука',GETDATE(),GETDATE())

GO
