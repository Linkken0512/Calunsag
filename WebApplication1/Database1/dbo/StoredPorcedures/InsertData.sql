CREATE PROCEDURE [dbo].[InsertData]
	@name NVARCHAR(100) 
AS
begin
	insert into dbo.TestTable (TestName)
	values (@name)
end
