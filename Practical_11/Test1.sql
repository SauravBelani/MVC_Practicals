use dbTest

go
--create table 
create table Employee(
	Id int Primary Key Identity,
	FirstName varchar (50) Not Null,
	MiddleName varchar(50),
	Lastname varchar(50) not null,
	DOB date not null,
	MobileNumber varchar(10) not null,
	Address1 varchar(100)
);

--insert records
insert into Employee values('Saurav','M','Belani','2000-03-05','9265866744','Khambhat')
insert into Employee values('Arpan','B','Thakkar','1999-11-19','9265866744','Khambhat')
insert into Employee values('Ramesh','M','Kant','2003-01-25','9265866744','Khambhat')
insert into Employee values('Suresh','M','Hatela','1995-07-13','9265866744','Khambhat')
insert into Employee values('chandresh','M','Gandhi','1998-05-08','9265866744','Khambhat')

--display table
select * from Employee

--Update query to change the First Name to “SQLPerson” for the first record
update Employee set FirstName='SQLPerson' where id=1 

--Update query to change the Middle Name to “I” for all records
update Employee set MiddleName='I'

--delete query to delete record having Id column value less than 2
delete Employee where id<2

--query to delete all the data from the table
delete Employee