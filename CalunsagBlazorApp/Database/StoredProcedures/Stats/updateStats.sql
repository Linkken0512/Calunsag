CREATE PROCEDURE [dbo].[updateStats]
	@StatId INT, 
    @str INT,
    @agi INT,
    @mgc INT,
    @knw INT,
    @elm INT,
    @title INT

as
begin
update [Stats]
set
[str]=isnull(@str,[str]),
agi=isnull(@agi,agi),
mgc=isnull(@mgc,mgc),
knw=isnull(@knw,knw),
elm=isnull(@elm,elm),
title=isnull(@title,title)
where StatId = @StatId
end