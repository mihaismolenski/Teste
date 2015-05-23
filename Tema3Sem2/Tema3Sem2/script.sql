USE [Teste]
GO

/****** Object:  Table [dbo].[Domeniu]    Script Date: 5/23/2015 12:40:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Domeniu](
	[IdDomeniu] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](50) NULL,
	[Descriere] [nvarchar](max) NULL,
 CONSTRAINT [PK_Domeniu] PRIMARY KEY CLUSTERED 
(
	[IdDomeniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

USE [Teste]
GO

/****** Object:  Table [dbo].[Subdomeniu]    Script Date: 5/23/2015 12:41:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subdomeniu](
	[IdSubdomeniu] [int] IDENTITY(1,1) NOT NULL,
	[IdDomeniu] [int] NULL,
	[Nume] [nvarchar](50) NULL,
	[Descriere] [nvarchar](max) NULL,
 CONSTRAINT [PK_Subdomeniu] PRIMARY KEY CLUSTERED 
(
	[IdSubdomeniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Subdomeniu]  WITH CHECK ADD  CONSTRAINT [FK_Subdomeniu_Domeniu] FOREIGN KEY([IdDomeniu])
REFERENCES [dbo].[Domeniu] ([IdDomeniu])
GO

ALTER TABLE [dbo].[Subdomeniu] CHECK CONSTRAINT [FK_Subdomeniu_Domeniu]
GO

USE [Teste]
GO

/****** Object:  Table [dbo].[Cursant]    Script Date: 5/23/2015 12:42:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cursant](
	[IdCursant] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Hint] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cursant] PRIMARY KEY CLUSTERED 
(
	[IdCursant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Teste]
GO

/****** Object:  Table [dbo].[Test]    Script Date: 5/23/2015 12:42:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Test](
	[IdTest] [int] IDENTITY(1,1) NOT NULL,
	[IdCursant] [int] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[IdTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_Test] FOREIGN KEY([IdCursant])
REFERENCES [dbo].[Cursant] ([IdCursant])
GO

ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_Test]
GO


USE [Teste]
GO

/****** Object:  Table [dbo].[Intrebare]    Script Date: 5/23/2015 12:42:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Intrebare](
	[IdIntrebare] [int] IDENTITY(1,1) NOT NULL,
	[IdDomeniu] [int] NULL,
	[IdSubdomeniu] [int] NULL,
	[Text] [nvarchar](50) NOT NULL,
	[Tip] [int] NOT NULL,
 CONSTRAINT [PK_Intrebare] PRIMARY KEY CLUSTERED 
(
	[IdIntrebare] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Intrebare]  WITH CHECK ADD  CONSTRAINT [FK_Intrebare_Domeniu] FOREIGN KEY([IdDomeniu])
REFERENCES [dbo].[Domeniu] ([IdDomeniu])
GO

ALTER TABLE [dbo].[Intrebare] CHECK CONSTRAINT [FK_Intrebare_Domeniu]
GO

ALTER TABLE [dbo].[Intrebare]  WITH CHECK ADD  CONSTRAINT [FK_Intrebare_Subdomeniu] FOREIGN KEY([IdSubdomeniu])
REFERENCES [dbo].[Subdomeniu] ([IdSubdomeniu])
GO

ALTER TABLE [dbo].[Intrebare] CHECK CONSTRAINT [FK_Intrebare_Subdomeniu]
GO


USE [Teste]
GO

/****** Object:  Table [dbo].[VariantaRaspuns]    Script Date: 5/23/2015 12:42:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VariantaRaspuns](
	[IdRaspuns] [int] IDENTITY(1,1) NOT NULL,
	[IdIntrebare] [int] NULL,
	[Text] [nvarchar](max) NULL,
	[Corect] [bit] NULL,
	[Motivatie] [nvarchar](50) NULL,
 CONSTRAINT [PK_Raspuns] PRIMARY KEY CLUSTERED 
(
	[IdRaspuns] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[VariantaRaspuns]  WITH CHECK ADD  CONSTRAINT [FK_Raspuns_Raspuns] FOREIGN KEY([IdIntrebare])
REFERENCES [dbo].[Intrebare] ([IdIntrebare])
GO

ALTER TABLE [dbo].[VariantaRaspuns] CHECK CONSTRAINT [FK_Raspuns_Raspuns]
GO


USE [Teste]
GO

/****** Object:  Table [dbo].[RaspunsCursant]    Script Date: 5/23/2015 12:43:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RaspunsCursant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTest] [int] NOT NULL,
	[IdIntrebare] [int] NOT NULL,
	[IdRaspuns] [int] NOT NULL,
 CONSTRAINT [PK_RaspunsCursant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RaspunsCursant]  WITH CHECK ADD  CONSTRAINT [FK_RaspunsCursant_Intrebare] FOREIGN KEY([IdIntrebare])
REFERENCES [dbo].[Intrebare] ([IdIntrebare])
GO

ALTER TABLE [dbo].[RaspunsCursant] CHECK CONSTRAINT [FK_RaspunsCursant_Intrebare]
GO

ALTER TABLE [dbo].[RaspunsCursant]  WITH CHECK ADD  CONSTRAINT [FK_RaspunsCursant_RaspunsCursant] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([IdTest])
GO

ALTER TABLE [dbo].[RaspunsCursant] CHECK CONSTRAINT [FK_RaspunsCursant_RaspunsCursant]
GO

ALTER TABLE [dbo].[RaspunsCursant]  WITH CHECK ADD  CONSTRAINT [FK_RaspunsCursant_VariantaRaspuns] FOREIGN KEY([IdRaspuns])
REFERENCES [dbo].[VariantaRaspuns] ([IdRaspuns])
GO

ALTER TABLE [dbo].[RaspunsCursant] CHECK CONSTRAINT [FK_RaspunsCursant_VariantaRaspuns]
GO



