CREATE PROCEDURE [dbo].[createProf]
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Age INT, 
    @Lvl INT
as
begin
insert into Profiles (FirstName, LastName, Age, Lvl)
values (@FirstName, @LastName, @Age, @Lvl)
end
