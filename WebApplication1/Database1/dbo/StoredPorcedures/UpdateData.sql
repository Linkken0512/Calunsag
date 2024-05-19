CREATE PROCEDURE [dbo].[UpdateData]
	@id int,
	@name NVARCHAR(100) 
AS
begin
	update dbo.TestTable 
	set TestName = @name
	where id = @id
end
