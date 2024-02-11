CREATE PROCEDURE [dbo].[searchProf]
	@Key nvarchar(50)
AS
begin
Select 
FirstName as FirstName,
LastName as LastName,
Age as Age,
Lvl as Lvl,
Id as Id
from Profiles
where 
FirstName like @Key or
LastName like @Key or
Age like @Key or
Lvl like @Key or
Id like @Key
order by FirstName asc
end