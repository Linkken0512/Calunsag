CREATE PROCEDURE [dbo].[deleteStats]
	@StatId INT, 
    @str INT,
    @agi INT,
    @mgc INT,
    @knw INT,
    @elm INT,
    @title INT

as
begin
delete [Stats]
where @StatId = StatId
end
