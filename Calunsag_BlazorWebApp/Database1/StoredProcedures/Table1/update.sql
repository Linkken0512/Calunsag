CREATE PROCEDURE [dbo].[update]
	@Id NVARCHAR(50) , 
    @FName NVARCHAR(50)
AS
begin
	update [dbo].Table1
	set 
	FName = ISNULL(@FName,FName)
	where 
	Id = @Id
end