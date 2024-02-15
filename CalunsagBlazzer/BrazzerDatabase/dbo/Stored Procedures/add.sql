CREATE PROCEDURE [dbo].[add]
	@Id NVARCHAR(50), 
    @Name NVARCHAR(50), 
    @Nickname NVARCHAR(50)
AS
begin
Insert into [dbo].[Table1] ([Id],[Name],[Nickname]) values (@Id,@Name,@Nickname)
end