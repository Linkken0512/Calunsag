CREATE PROCEDURE [dbo].[displayProf]
	@Id INT
as
begin
select *
from Profiles
where @Id = Id
end