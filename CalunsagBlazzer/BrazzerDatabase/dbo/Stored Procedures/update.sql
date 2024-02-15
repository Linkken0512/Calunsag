CREATE PROCEDURE [dbo].[update]
	@Id NVARCHAR(50), 
    @Name NVARCHAR(50), 
    @Nickname NVARCHAR(50)
AS
begin
update [dbo].[Table1] set [Name] = isnull (@Name,[Name]), [Nickname] = isnull (@Nickname,[Nickname]) where [Id] = @Id
end
