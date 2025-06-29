CREATE TABLE Employees
(
FirstName varchar(20),
LastName varchar(20),
DepartmentID int,
Salary Decimal(10,2),
JoinDate Date);

CREATE PROCEDURE sp_InsertEmployees 
@FirstName VARCHAR(50), 
@LastName VARCHAR(50), 
@DepartmentID INT, 
@Salary DECIMAL(10,2), 
@JoinDate DATE 
AS 
BEGIN 
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate); 
END;

EXEC sp_InsertEmployees
@FirstName = 'James',
@LastName = 'Watt',
@DepartmentID = 1,
@Salary = 65000.00,
@JoinDate = '2016-02-25';

CREATE PROCEDURE sp_GetEmployeesByDepartmentID
    @DepartmentID INT
AS
BEGIN
    SELECT 
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;

EXEC sp_GetEmployeesByDepartmentID
@DepartmentID = 1;
