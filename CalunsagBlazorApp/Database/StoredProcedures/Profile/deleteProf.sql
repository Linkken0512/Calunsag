CREATE PROCEDURE [dbo].[deleteProf]
	@Id INT, 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Age INT, 
    @Lvl INT
as
begin
delete Profiles
where @Id = Id
end
