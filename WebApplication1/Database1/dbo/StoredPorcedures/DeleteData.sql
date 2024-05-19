CREATE PROCEDURE [dbo].[DeleteData]
	@id int
AS
begin
	delete from dbo.TestTable
	where id = @id
end
