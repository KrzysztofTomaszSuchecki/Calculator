IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'CalculatorDb')
  BEGIN
    CREATE DATABASE [CalculatorDb]
  END
GO
	USE [CalculatorDb]
GO


/****** Object:  Table [dbo].[OperaionsTypes]    Script Date: 5/29/2021 1:40:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OperaionsTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Operation]    Script Date: 5/29/2021 1:05:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Operation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[No1] [float] NOT NULL,
	[No2] [float] NOT NULL,
	[Result] [float] NOT NULL,
	[OperaionTypeId] [int] NOT NULL,
	[OperationDateTime] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Operation]  WITH CHECK ADD FOREIGN KEY([OperaionTypeId])
REFERENCES [dbo].[OperaionsTypes] ([Id])
GO

