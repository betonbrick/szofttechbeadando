select HASHBYTES('MD5', 'admin')
 

SELECT CONVERT(NVARCHAR(255),HashBytes('MD5', 'admin'),2)
 

insert into Admins (Id, Username, Password) values (2,'admin', (SELECT CONVERT(NVARCHAR(255),HashBytes('MD5', 'admin'),2)))