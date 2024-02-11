CREATE PROCEDURE [dbo].[delete]
	@Id NVARCHAR(50) , 
    @FName NVARCHAR(50)
AS
begin
	delete from  [dbo].Table1 
	where Id = @Id
end
