﻿CREATE TABLE [dbo].[Ingredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[Price] MONEY NOT NULL
)
