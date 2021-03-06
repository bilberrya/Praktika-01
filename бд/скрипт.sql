USE [44-Практика-Иконникова А.В.-2022]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 3/5/2022 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[id] [int] IDENTITY(801,1) NOT NULL,
	[id_user] [int] NULL,
	[id_lab] [int] NULL,
	[id_service] [int] NULL,
	[result] [nchar](1) NULL,
	[data] [varchar](12) NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 3/5/2022 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id] [int] NOT NULL,
	[service] [nchar](20) NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/5/2022 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NULL,
	[login] [varchar](15) NULL,
	[password] [varchar](15) NULL,
	[gender] [nchar](1) NULL,
	[age] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 3/5/2022 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[id] [int] IDENTITY(501,1) NOT NULL,
	[name] [varchar](30) NULL,
	[login] [varchar](15) NULL,
	[password] [varchar](15) NULL,
	[ip] [varchar](15) NULL,
	[lastenter] [varchar](12) NULL,
	[dolgnost] [varchar](15) NULL,
	[analyzator] [varchar](10) NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (801, 1, 501, 557, N'+', N'2019-10-22')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (802, 1, 501, 836, N'-', N'2019-10-23')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (803, 1, 501, 287, N'+', N'2019-10-24')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (804, 2, 502, 855, N'-', N'2019-10-25')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (805, 2, 502, 619, N'+', N'2019-10-26')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (806, 2, 502, 557, N'-', N'2019-10-27')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (807, 2, 502, 836, N'+', N'2019-10-28')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (808, 2, 502, 548, N'-', N'2019-10-29')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (809, 3, 501, 543, N'+', N'2019-10-30')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (810, 3, 501, 836, N'-', N'2019-10-31')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (811, 4, 501, 855, N'+', N'2019-11-01')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (812, 4, 501, 258, N'-', N'2019-11-02')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (813, 5, 501, 543, N'+', N'2019-11-03')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (814, 5, 501, 415, N'-', N'2019-11-04')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (815, 5, 501, 619, N'+', N'2019-11-05')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (816, 5, 501, 557, N'-', N'2019-11-06')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (817, 6, 502, 557, N'+', N'2019-11-07')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (818, 6, 502, 836, N'-', N'2019-11-08')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (819, 6, 502, 229, N'+', N'2019-11-09')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (820, 7, 502, 287, N'-', N'2019-11-10')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (821, 7, 502, 619, N'+', N'2019-11-11')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (822, 7, 502, 548, N'-', N'2019-11-12')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (823, 7, 502, 346, N'+', N'2019-11-13')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (824, 8, 502, 415, N'-', N'2019-11-14')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (825, 8, 502, 311, N'+', N'2019-11-15')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (826, 8, 502, 176, N'-', N'2019-11-16')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (827, 8, 502, 855, N'+', N'2019-11-17')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (828, 9, 503, 323, N'-', N'2019-11-18')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (829, 9, 503, 548, N'+', N'2019-11-19')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (830, 9, 503, 346, N'-', N'2019-11-20')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (831, 10, 503, 229, N'+', N'2019-11-21')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (832, 10, 503, 346, N'-', N'2019-11-22')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (833, 10, 503, 501, N'+', N'2019-11-23')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (834, 10, 503, 548, N'-', N'2019-11-24')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (835, 11, 502, 287, N'+', N'2019-11-25')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (836, 12, 502, 619, N'-', N'2019-11-26')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (837, 12, 502, 258, N'+', N'2019-11-27')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (838, 12, 502, 229, N'-', N'2019-11-28')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (839, 12, 502, 557, N'+', N'2019-11-29')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (840, 12, 502, 797, N'-', N'2019-11-30')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (841, 13, 501, 323, N'+', N'2019-12-01')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (842, 13, 501, 311, N'-', N'2019-12-02')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (843, 13, 501, 557, N'+', N'2019-12-03')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (844, 14, 503, 855, N'-', N'2019-12-04')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (845, 14, 503, 176, N'+', N'2019-12-05')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (846, 14, 503, 176, N'-', N'2019-12-06')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (847, 14, 503, 855, N'+', N'2019-12-07')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (848, 15, 503, 229, N'-', N'2019-12-08')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (849, 15, 503, 836, N'+', N'2019-12-09')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (850, 15, 503, 287, N'-', N'2019-12-10')
INSERT [dbo].[Results] ([id], [id_user], [id_lab], [id_service], [result], [data]) VALUES (851, 15, 503, 619, N'+', N'2019-12-11')
SET IDENTITY_INSERT [dbo].[Results] OFF
GO
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (176, N'Билирубин общий     ', 102.85)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (229, N'СПИД                ', 341.78)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (258, N'Креатинин           ', 143.22)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (287, N'Волчаночный антикоаг', 290.11)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (311, N'Амилаза             ', 361.88)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (323, N'Глюкоза             ', 447.65)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (346, N'Общий белок         ', 396.03)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (415, N'Кальций общий       ', 419.9)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (501, N'Гепатит В           ', 176.83)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (543, N'Гепатит С           ', 289.99)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (548, N'Альбумин            ', 234.09)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (557, N'ВИЧ                 ', 490.77)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (619, N'TSH                 ', 262.71)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (659, N'Сифилис RPR         ', 443.66)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (797, N'АТ и АГ к ВИЧ 1/2   ', 370.62)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (836, N'Железо              ', 105.32)
INSERT [dbo].[Service] ([id], [service], [price]) VALUES (855, N'Ковид IgM           ', 209.78)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (1, N'Clareta Hacking ', N'chacking0', N'4tzqHdkqzo4', N'ж', 21)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (2, N'Northrop Mably', N'nmably1', N'ukM0e6', N'м', 25)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (3, N'Fabian Rolf', N'frolf2', N'7QpCwac0yi', N'м', 62)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (4, N'Lauree Raden', N'lraden3', N'5Ydp2mz', N'ж', 34)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (5, N'Barby Follos', N'bfollos4', N'ckmAJPQV', N'ж', 38)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (6, N'Mile Enterle', N'menterle5', N'0PRom6i', N'м', 19)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (7, N'Midge Peaker', N'mpeaker6', N'0Tc5oRc', N'м', 22)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (8, N'Manon Robichon', N'mrobichon7', N'LEwEjMlmE5X', N'м', 19)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (9, N'Stavro Robken', N'srobken8', N'Cbmj3Yi', N'м', 37)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (10, N'Bryan Tidmas', N'btidmas9', N'dYDHbBQfK', N'м', 28)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (11, N'Jeannette Fussie', N'jfussiea', N'EGxXuLQ9', N'ж', 33)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (12, N'Stephen Antonacci', N'santonaccib', N'YcXAhY3Pja', N'м', 17)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (13, N'Niccolo Bountiff', N'nbountiffc', N'5xfyjS9ZULGA', N'м', 90)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (14, N'Clemente Benjefield', N'cbenjefieldd', N'tQOsP0ei9TuD', N'м', 72)
INSERT [dbo].[Users] ([id], [name], [login], [password], [gender], [age]) VALUES (15, N'Orlan Corbyn', N'ocorbyne', N'bG1ZIzwIoU', N'м', 49)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Workers] ON 

INSERT [dbo].[Workers] ([id], [name], [login], [password], [ip], [lastenter], [dolgnost], [analyzator]) VALUES (501, N'Elvin Leonard', N'elnard32', N'WhtpSgj89', N'105.215.34.15', N'2020-12-30', N'lab', N'Ledetect')
INSERT [dbo].[Workers] ([id], [name], [login], [password], [ip], [lastenter], [dolgnost], [analyzator]) VALUES (502, N'Anissa Hood', N'hoody27', N'hTdgOj296', N'99.105.204.72', N'2020-12-31', N'lab', N'Biorad')
INSERT [dbo].[Workers] ([id], [name], [login], [password], [ip], [lastenter], [dolgnost], [analyzator]) VALUES (503, N'Michael Hamilto', N'michael9', N'pghaYiw2Js3', N'255.167.21.10', N'2020-12-29', N'lab', N'Ledetect')
INSERT [dbo].[Workers] ([id], [name], [login], [password], [ip], [lastenter], [dolgnost], [analyzator]) VALUES (504, N'Edwin Brooks', N'brook13', N'friw9Tejd', N'215.78.210.255', N'2020-12-31', N'admin', NULL)
SET IDENTITY_INSERT [dbo].[Workers] OFF
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Service] FOREIGN KEY([id_service])
REFERENCES [dbo].[Service] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Service]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Users]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Workers] FOREIGN KEY([id_lab])
REFERENCES [dbo].[Workers] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Workers]
GO
