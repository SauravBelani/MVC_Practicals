use dbTest

go

create procedure Stored
as
insert into Designation values('Software Er.')
go

create procedure Stored1
as
insert into Employee values('Saurav','M','Belani','2000-03-05','9265866744','Khambhat',33333,3)
go

create procedure Stored2
as
select Employee.Id,Employee.FirstName,Employee.MiddleName,Employee.Lastname,Designation.Designation,Employee.DOB,Employee.MobileNumber,Employee.Address1,Employee.Salary 
from Employee
inner join Designation on Employee.DesignationId=Designation.id
order by Employee.DOB
go

create procedure Stored3(@abc int)
as
select Employee.Id,Employee.FirstName,Employee.MiddleName,Employee.Lastname,Designation.Designation,Employee.DOB,Employee.MobileNumber,Employee.Address1,Employee.Salary 
from Employee
inner join Designation on Employee.DesignationId=Designation.id
where Employee.DesignationId=@abc
order by Employee.FirstName
go

DROP PROCEDURE dbo.Stored3
GO

create view Vdatabase as
select Employee.Id,Employee.FirstName,Employee.MiddleName,Employee.Lastname,Designation.Designation,Employee.DOB,Employee.MobileNumber,Employee.Address1,Employee.Salary 
from Employee
inner join Designation on Employee.DesignationId=Designation.id