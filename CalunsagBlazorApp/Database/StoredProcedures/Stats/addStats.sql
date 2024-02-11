CREATE PROCEDURE [dbo].[addStats]
	@StatId INT, 
    @str INT,
    @agi INT,
    @mgc INT,
    @knw INT,
    @elm INT,
    @title INT

as
begin
insert into [Stats] (StatId, [str], agi, mgc, knw, elm, title)
values (@StatId, @str, @agi, @mgc, @knw, @elm, @title)
end

