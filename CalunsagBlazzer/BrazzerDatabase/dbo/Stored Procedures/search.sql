CREATE PROCEDURE [dbo].[search]
	@Key NVARCHAR(50)
AS
begin
SELECT [Id] as r1, [Name] as r2, [Nickname] as r3 
FROM [dbo].[Table1] 
WHERE 
[Id] LIKE  @Key  OR 
[Name] LIKE  @Key  OR 
[Nickname] LIKE  @Key  
ORDER BY [Name];
end
