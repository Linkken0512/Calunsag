CREATE PROCEDURE [dbo].[SelectData]
	@id int
AS
begin
	select * from dbo.TestTable
	where id = @id
end
