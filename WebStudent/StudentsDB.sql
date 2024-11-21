use master
go
if exists (select name from sys.databases where name = 'StudentsDB')
begin
    alter database StudentsDB set single_user with rollback immediate
    drop database StudentsDB
end
go
create database StudentsDB
go
use StudentsDB
go

-- Create the Students table
create table Students
(
    Id int primary key identity(1, 1),
    Name nvarchar(50) not null,
    Surname nvarchar(50) not null,
    BirthDate datetime,
    GPA decimal(9, 1),
    CourseId int -- Foreign key column for the relationship
)

-- Create the Course table
create table Course
(
    Id int primary key identity(1, 1),
    Name nvarchar(100) not null
)

-- Add the foreign key constraint
alter table Students
add constraint FK_Students_Course foreign key (CourseId) references Course(Id)
