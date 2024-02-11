CREATE PROCEDURE [dbo].[select]
	@Id NVARCHAR(50) , 
    @FName NVARCHAR(50)
AS
begin
	SELECT
	Id,
	FName
	from [dbo].Table1
end
