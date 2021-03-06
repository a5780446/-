USE [sanjinuse]
GO
/****** Object:  Table [dbo].[ask]    Script Date: 2021/12/13 下午 11:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ask](
	[orderid] [nvarchar](50) NOT NULL,
	[vendor] [nvarchar](50) NULL,
	[material] [nvarchar](50) NULL,
	[product] [nvarchar](50) NOT NULL,
	[format] [nvarchar](50) NULL,
	[unit] [nvarchar](50) NULL,
	[price] [float] NULL,
	[process] [nvarchar](50) NULL,
	[askdate] [nvarchar](50) NULL,
	[state] [nvarchar](50) NULL,
	[remark] [nvarchar](50) NULL,
	[qty] [float] NULL,
	[buyunit] [nvarchar](50) NULL,
	[needdate] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[agreement] [nvarchar](50) NULL,
	[qtyleft] [float] NULL,
	[vprice] [float] NULL,
 CONSTRAINT [PK_ask] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inlog]    Script Date: 2021/12/13 下午 11:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inlog](
	[inid] [nvarchar](50) NULL,
	[vendor] [nvarchar](50) NULL,
	[material] [nvarchar](50) NULL,
	[product] [nvarchar](50) NULL,
	[format] [nvarchar](50) NULL,
	[indate] [nvarchar](50) NULL,
	[inqty] [float] NULL,
	[leftqty] [float] NULL,
	[inmoney] [float] NULL,
	[totalprice] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vendor]    Script Date: 2021/12/13 下午 11:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendor](
	[name] [nvarchar](50) NOT NULL,
	[nikename] [nvarchar](50) NULL,
	[number] [nchar](10) NOT NULL,
	[tel] [nvarchar](50) NULL,
	[firstconn] [nvarchar](50) NULL,
	[secconn] [nvarchar](50) NULL,
	[adress] [nvarchar](50) NULL,
	[remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_vendor] PRIMARY KEY CLUSTERED 
(
	[number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ask] ADD  CONSTRAINT [DF_ask_state]  DEFAULT (N'未核') FOR [state]
GO
ALTER TABLE [dbo].[ask] ADD  CONSTRAINT [DF_ask_remark]  DEFAULT (N'無備註') FOR [remark]
GO
