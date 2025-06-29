--creating table
CREATE TABLE Students
(
Name varchar(20),
RegisterID varchar(10),
DepartmentID int,
Department varchar(5),
email varchar(20));
--create store procedure
CREATE PROCEDURE sp_GetStudentsCountByDepartmentID
@DepartmentID INT
AS
BEGIN
-- count of total students
   SELECT
   COUNT(*) AS TotalStudents
   FROM
   Students
   WHERE
   DepartmentID=@DepartmentID
 END;
 --create store procedure to insert
CREATE PROCEDURE sp_InsertStudents 
@Name VARCHAR(20), 
@RegisterID VARCHAR(10),
@DepartmentID INT, 
@Department varchar(5),
@email varchar(20) 
AS 
BEGIN 
INSERT INTO Students (Name, RegisterID, DepartmentID, Department, email) 
VALUES (@Name, @RegisterID, @DepartmentID, @Department, @email); 
END; 
--Inserting Valuse in sp
EXEC sp_InsertStudents
@Name = 'RAMKI', 
@RegisterID = 'CN347',
@DepartmentID = 3, 
@Department = 'CSE',
@email ='RamkiCSE@gmail.com' ;
--Retriving Data
EXEC sp_GetStudentsCountByDepartmentID
@DepartmentID = 3;