CREATE PROCEDURE [dbo].[create]
	@Id NVARCHAR(50) , 
    @FName NVARCHAR(50)
AS
begin
	insert into [dbo].Table1
	(
	Id,
	FName
	) 
	values
	(
	@Id,
	@FName
	)
end
