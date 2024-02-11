CREATE PROCEDURE [dbo].[displayProf]
	@Id INT, 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Age INT, 
    @Lvl INT
as
begin
select *
from Profiles
where @Id = Id
end