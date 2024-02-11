CREATE PROCEDURE [dbo].[createProf]
	@Id INT, 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Age INT, 
    @Lvl INT
as
begin
insert into Profiles (Id, FirstName, LastName, Age, Lvl)
values (@Id, @FirstName, @LastName, @Age, @Lvl)
end
