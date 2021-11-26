USE master
GO

if exists (select * from sysdatabases where name='hospitalmgmntdb')
		drop database hospitalmgmntdb

create database hospitalmgmntdb

use hospitalmgmntdb
GO

drop table if exists hospitalmgmntdb.dbo.Employees
drop table if exists hospitalmgmntdb.dbo.Patients

create table Employees
(
	Id int not null,
	Name varchar(50) not null,
	Age int not null,
	Occupation varchar(10) not null,
	Address varchar(100) not null,
	Email varchar(100) not null,
	Phone int not null,
	Speciality varchar(50) not null,
	Salary int not null,
	constraint pk_Employees primary key(Id)
)

create table Patients
(
	Id int not null,
	Name varchar(50) not null,
	Age int not null,
	Class varchar(30) not null,
	Address varchar(100) not null,
	Email varchar(100) not null,
	Phone int not null,
	constraint pk_Patients primary key(Id)
)