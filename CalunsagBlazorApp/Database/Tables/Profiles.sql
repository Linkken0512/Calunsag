CREATE TABLE [dbo].[Profiles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [Lvl] INT NULL
)
