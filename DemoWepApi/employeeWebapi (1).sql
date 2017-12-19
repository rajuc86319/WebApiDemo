create database EmployeeDB

use EmployeeDB

Create table Employees
(
Id int primary key Identity,
FirstName nvarchar(50),
LastName nvarchar(50),
Gender nvarchar(50),
Salary int 
)
alter table Employees alter column Salary float

insert into Employees values('Neelam', 'Rajendra naidu','male',6)
insert into Employees values('Ajay kumar', 'maddala','male',6)
insert into Employees values('Divya','Gandivalasa','female',6.5)
insert into Employees values('Abdul vaasi', 'Mohammed','male',6)
insert into Employees values('srikanth', 'macha','male',6)
insert into Employees values('manikanta', 'jami','male',6)
select *from Employees

Create Table Users
(
     Id int identity primary key,
     Username nvarchar(100),
     Password nvarchar(100)
)

Insert into Users values ('male','male')
Insert into Users values ('female','female')
