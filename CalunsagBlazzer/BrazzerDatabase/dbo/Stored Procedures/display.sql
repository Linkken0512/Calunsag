CREATE PROCEDURE [dbo].[display]
	@Id NVARCHAR(50), 
    @Name NVARCHAR(50), 
    @Nickname NVARCHAR(50)
AS
begin
select [Id] as r1, [Name] as r2, [Nickname] as r3 from [dbo].[Table1]
end
