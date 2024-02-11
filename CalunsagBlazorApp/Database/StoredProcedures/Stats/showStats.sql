CREATE PROCEDURE [dbo].[showStats]
	@StatId INT, 
    @str INT,
    @agi INT,
    @mgc INT,
    @knw INT,
    @elm INT,
    @title INT

as
begin
select *
from [Stats]
where @StatId = StatId
end
