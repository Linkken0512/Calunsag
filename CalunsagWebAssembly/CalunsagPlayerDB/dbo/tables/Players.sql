CREATE TABLE [dbo].[Players]
(
	[PlayerId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [PlayerName] NVARCHAR(50) NULL, 
    [Level] NVARCHAR(50) NULL, 
    [Job] NVARCHAR(50) NULL, 
    [Class] NVARCHAR(50) NULL, 
    [Guild] NVARCHAR(50) NULL
)
