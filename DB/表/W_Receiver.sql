USE [Codematic]
GO
/****** 对象:  Table [dbo].[W_Receiver]    脚本日期: 03/27/2010 09:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[W_Receiver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Receiver] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_W_Receiver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
