use dbTest

go

drop table Employee
--create table Designation
create table Designation(
	id int primary key Identity,
	Designation Varchar (50) not null
);

--insert values in Designation table
insert into Designation values('Software Er.')
insert into Designation values('Trainees Er.')
insert into Designation values('Lead Er.')

--craete Employee table with fk to Designation(id) table
create table Employee(
	Id int Primary Key Identity,
	FirstName varchar (50) Not Null,
	MiddleName varchar(50),
	Lastname varchar(50) not null,
	DOB date not null,
	MobileNumber varchar(10) not null,
	Address1 varchar(100),
	Salary Decimal,
	DesignationId int,
	FOREIGN KEY (DesignationId) REFERENCES Designation(id)	
);

--insert records in Employee table
insert into Employee values('Saurav','M','Belani','2000-03-05','9265866744','Khambhat',33333,3)
insert into Employee values('Arpan','B','Thakkar','1999-11-19','9265866744','Khambhat',40000,3)
insert into Employee values('Ramesh','M','Kant','2003-01-25','9265866744','Khambhat',20000,2)
insert into Employee values('Suresh','M','Hatela','1995-07-13','9265866744','Khambhat',15000,2)
insert into Employee values('chandresh','M','Gandhi','1998-05-08','9265866744','Khambhat',10000,1)

--query to count the number of records by designation name
select COUNT(*) as NoOfDesignation from Designation

--query to display First Name, Middle Name, Last Name & Designation name
select Employee.FirstName,Employee.MiddleName,Employee.Lastname,Designation.Designation 
from Employee
inner join Designation on Employee.DesignationId=Designation.id

--display view
select * from Vdatabase;

--display  stored procedure
exec Stored;

--display  stored procedure
exec Stored1;

--query that displays only those designation names that have more than 1 employee
SELECT D.Designation FROM
Designation D WHERE (SELECT COUNT(*) 
                    FROM Employee E 
                    WHERE E.DesignationId = D.id) > 1

--display  stored procedure
exec Stored2;

--display  stored procedure
exec Stored3 2;

--Create Non-Clustered index on the DesignationId column of the Employee table
CREATE NONCLUSTERED INDEX NCI_Employee_DesignationId
ON dbo.Employee(DesignationId);

--execute sp_helpindex employee ;

--query to find the employee having maximum salary
select * from Employee where Salary=(select max(Salary) from Employee)