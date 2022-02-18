use dbTest

go

drop table Employee
--create table
create table Employee(
	Id int Primary Key Identity,
	FirstName varchar (50) Not Null,
	MiddleName varchar(50),
	Lastname varchar(50) not null,
	DOB date not null,
	MobileNumber varchar(10) not null,
	Address1 varchar(100),
	Salary Decimal
);

--Insert records in the above table
insert into Employee values('Saurav','M','Belani','2000-03-05','9265866744','Khambhat',33333)
insert into Employee values('Arpan','B','Thakkar','1999-11-19','9265866744','Khambhat',40000)
insert into Employee values('Ramesh','M','Kant','2003-01-25','9265866744','Khambhat',20000)
insert into Employee values('Suresh','M','Hatela','1995-07-13','9265866744','Khambhat',15000)
insert into Employee values('chandresh','M','Gandhi','1998-05-08','9265866744','Khambhat',10000)

-- display
select * from Employee

--SQL query to find the total amount of salaries
select Sum(Salary) from Employee

--SQL query to find all employees having DOB less than 01-01-2000
select * from Employee where DOB < '01-01-2000'

--SQL query to count employees having Middle Name NULL
select COUNT(*) from Employee where MiddleName=''