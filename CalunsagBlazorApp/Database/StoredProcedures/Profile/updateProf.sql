CREATE PROCEDURE [dbo].[updateProf]
	@Id INT, 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Age INT, 
    @Lvl INT
as
begin
update Profiles
set
FirstName=isnull(@FirstName,FirstName),
LastName=isnull(@LastName,LastName),
Age=isnull(@Age,Age),
Lvl=isnull(@Lvl,Lvl)
where Id = @Id
end